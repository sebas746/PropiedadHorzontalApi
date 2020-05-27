using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using PropiedadHorizontal.Data.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PropiedadHorizontal.Business.Services
{
    public class CopropiedadesService : ICopropiedadesService
    {
        private readonly ICopropiedadesRepository _copropiedadesRepository;
        private readonly ICopropietariosRepository _copropietariosRepository;
        private readonly ICopropietariosService _copropietariosService;
        private readonly IResidentesService _residentesService;
        private readonly IMapper _mapper;

        public CopropiedadesService(ICopropiedadesRepository copropiedadesRepository
            , ICopropietariosRepository copropietariosRepository
            , ICopropietariosService copropietariosService
            , IResidentesService residentesService
            , IMapper mapper)
        {
            _copropietariosService = copropietariosService;
            _copropiedadesRepository = copropiedadesRepository;
            _copropietariosRepository = copropietariosRepository;
            _residentesService = residentesService;
            _mapper = mapper;
        }

        ///<see cref="ICopropiedadesService.GetAllCopropiedades(PaginationDto)"/>
        public IEnumerable<CopropiedadesDto> GetAllCopropiedades(PaginationDto paginationDto)
        {
            try
            {
                if (!GenericUtils<Copropiedades>.IsValidProperty(paginationDto.OrderBy, false))
                {
                    paginationDto.OrderBy = "NombreCopropiedad";
                }

                var pagination = _mapper.Map<Pagination>(paginationDto);

                var copropiedades = _copropiedadesRepository.GetAllCopropiedades(pagination);

                 return _mapper.Map<List<CopropiedadesDto>>(copropiedades);
            }

            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        ///<see cref="ICopropiedadesService.CreateCopropiedad(CopropiedadesDto)"/>
        public CopropiedadesDto CreateCopropiedad(CopropiedadesDto copropiedadDto)
        {
            try
            {
                var copropiedad = _mapper.Map<Copropiedades>(copropiedadDto);

                if(!_copropietariosRepository.ExistsCopropietario(copropiedadDto.IdDocumentoCopropietario))
                {
                    _copropietariosRepository.InsertCopropietario(copropiedad.Copropietario);
                }

                if(string.IsNullOrEmpty(copropiedad.IdDocumentoResidente))
                {
                    copropiedad.IdDocumentoResidente = null;
                    copropiedad.Residente = null;
                }

                _residentesService.UpdateResidente(copropiedad.Residente);

                copropiedad.Copropietario = null;
                var resultDto = _mapper.Map<CopropiedadesDto>(_copropiedadesRepository.InsertCopropiedad(copropiedad));
                return resultDto;
            }
            catch
            {
                throw;
            }
        }

        public bool CreateCopropiedades(List<CopropiedadesDto> copropiedadesDto)
        {
            try
            {
                var copropiedades = _mapper.Map<List<Copropiedades>>(copropiedadesDto);

                if(ExistsDuplicatedCopropiedades(copropiedades))
                {
                    throw new ValidationException("Hay más de una copropiedad con el mismo nombre. Por favor revise la información.");
                }

                //Get the nit copropiedad
                var nitCopropiedad = copropiedades.FirstOrDefault().NitPropiedadHorizontal;

                //Insert copropietarios in Database
                var copResult = _copropietariosService.InsertCopropietarios(copropiedadesDto.Select(co => co.Copropietario).ToList());

                if(copResult)
                {
                    //Get non existent copropietarios to insert them in Database
                    var nonExistentCopropiedades = _copropiedadesRepository.GetNonExistentCopropiedades(copropiedades, nitCopropiedad).ToList();
                    return _copropiedadesRepository.InsertBulkCopropiedades(nonExistentCopropiedades);
                }

                return false;
            }
            catch
            {
                throw;
            }
        }

        ///<see cref="ICopropiedadesService.GetCopropiedadById(int)"/>
        public CopropiedadesDto GetCopropiedadById(int copropiedadId)
        {
            try
            {
                var copropiedad = _copropiedadesRepository.GetCopropiedadById(copropiedadId);
                return _mapper.Map<CopropiedadesDto>(copropiedad);
            }
            catch
            {
                throw;
            }
        }

        ///<see cref="ICopropiedadesService.UpdateCopropiedad(CopropiedadesDto)"/>
        public CopropiedadesDto UpdateCopropiedad(CopropiedadesDto copropiedadDto)
        {
            try
            {
                var copropiedad = _mapper.Map<Copropiedades>(copropiedadDto);
                
                _residentesService.UpdateResidente(copropiedad.Residente);

                if(copropiedad.Copropietario != null)
                {
                    _copropietariosRepository.UpdateCopropietario(copropiedad.Copropietario);
                }

                var resultDto = _mapper.Map<CopropiedadesDto>(_copropiedadesRepository.UpdateCopropiedad(copropiedad));
                return resultDto;
            }
            catch
            {
                throw;
            }
        }

        ///<see cref="ICopropiedadesService.DeleteCopropiedad(int)"/>
        public bool DeleteCopropiedad(int copropiedadId)
        {
            try
            {
                return _copropiedadesRepository.DeleteCopropiedad(copropiedadId);
            }
            catch
            {
                throw;
            }
        }

        ///<see cref="ICopropiedadesService.ExistsCopropiedadNombre(string, int)"/>
        public bool ExistsCopropiedadNombre(string copropiedadNombre, int idCopropiedad)
        {
            try
            {
                return _copropiedadesRepository.ExistsCopropiedadNombre(copropiedadNombre, idCopropiedad);
            }
            catch
            {
                throw;
            }
        }

        public int Count()
        {
            return _copropiedadesRepository.Count();
        }

        private bool ExistsDuplicatedCopropiedades(List<Copropiedades> copropiedades)
        {
            var cop = copropiedades.Select(co => co.NombreCopropiedad).Distinct()
                    .GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => new { Element = y.Key, Counter = y.Count() })
                    .ToList();

            if(cop.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}

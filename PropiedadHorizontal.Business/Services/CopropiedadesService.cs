

using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using PropiedadHorizontal.Data.Utils;
using System;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services
{
    public class CopropiedadesService : ICopropiedadesService
    {
        private readonly ICopropiedadesRepository _copropiedadesRepository;
        private readonly ICopropietariosRepository _copropietariosRepository;
        private readonly IResidentesRepository _residentesRepository;
        private readonly IMapper _mapper;

        public CopropiedadesService(ICopropiedadesRepository copropiedadesRepository
            , ICopropietariosRepository copropietariosRepository
            , IResidentesRepository residentesRepository
            , IMapper mapper)
        {
            _copropiedadesRepository = copropiedadesRepository;
            _copropietariosRepository = copropietariosRepository;
            _residentesRepository = residentesRepository;
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

                if (!_residentesRepository.ExistsResidente(copropiedad.IdDocumentoResidente) && copropiedad.IdDocumentoResidente != null)
                {
                    _residentesRepository.InsertResidente(copropiedad.Residente);
                }

                copropiedad.Copropietario = null;
                var resultDto = _mapper.Map<CopropiedadesDto>(_copropiedadesRepository.InsertCopropiedad(copropiedad));
                return resultDto;
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
    }
}

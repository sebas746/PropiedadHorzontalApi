

using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropiedadHorizontal.Business.Services
{
    public class CopropiedadesService : ICopropiedadesService
    {
        private readonly ICopropiedadesRepository _copropiedadesRepository;
        private readonly IMapper _mapper;

        public CopropiedadesService(ICopropiedadesRepository copropiedadesRepository, IMapper mapper)
        {
            _copropiedadesRepository = copropiedadesRepository;
            _mapper = mapper;
        }

        ///<see cref="ICopropiedadesService.GetAllCopropiedades(PaginationDto)"/>
        public IEnumerable<CopropiedadesDto> GetAllCopropiedades(PaginationDto pagination)
        {
            try
            {
                if (!GenericUtils<Copropiedades>.IsValidProperty(pagination.OrderBy, false))
                {
                    pagination.OrderBy = "NombreCopropiedad";
                }

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
    }
}

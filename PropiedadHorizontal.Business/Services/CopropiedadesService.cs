﻿

using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
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

        public IEnumerable<CopropiedadesDto> GetAllCopropiedades(int skip, int take, string searchString, string sortOrder, string currentSort)
        {
            try
            {
                if (!GenericUtils<Copropiedades>.IsValidProperty(currentSort, false))
                {
                    currentSort = "NombreCopropiedad";
                }

                var copropiedades = _copropiedadesRepository.GetAllCopropiedades(skip, take, searchString, sortOrder, currentSort);

                 return _mapper.Map<List<CopropiedadesDto>>(copropiedades);
            }

            catch
            {
                throw;
            }
        }

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
    }
}

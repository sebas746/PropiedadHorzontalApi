

using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System.Collections.Generic;

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
                var copropiedades = _copropiedadesRepository.GetAllCopropiedades(skip, take, searchString, sortOrder, currentSort);

                 return _mapper.Map<List<CopropiedadesDto>>(copropiedades);
            }

            catch
            {
                throw;
            }
        }
    }
}

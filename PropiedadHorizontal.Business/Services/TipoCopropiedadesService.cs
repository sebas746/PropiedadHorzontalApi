using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services
{
    public class TipoCopropiedadesService : ITipoCopropiedadesService
    {
        private readonly ITipoCopropiedadesRepository _tipoCopropiedadesRepository;
        private readonly IMapper _mapper;

        public TipoCopropiedadesService(ITipoCopropiedadesRepository tipoCopropiedadesRepository, IMapper mapper)
        {
            _tipoCopropiedadesRepository = tipoCopropiedadesRepository;
            _mapper = mapper;
        }

        public IEnumerable<TipoCopropiedadesDto> GetAllTipoCopropiedades()
        {
            return _mapper.Map<IEnumerable<TipoCopropiedadesDto>>(_tipoCopropiedadesRepository.GetAllTipoCopropiedades());
        }
    }
}

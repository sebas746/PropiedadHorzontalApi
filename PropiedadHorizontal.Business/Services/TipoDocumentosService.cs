
using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services
{
    public class TipoDocumentosService : ITipoDocumentosService
    {
        private readonly ITipoDocumentosRepository _tipoDocumentosRepository;
        private readonly IMapper _mapper;

        public TipoDocumentosService(ITipoDocumentosRepository tipoDocumentosRepository, IMapper mapper)
        {
            _tipoDocumentosRepository = tipoDocumentosRepository;
            _mapper = mapper;
        }

        public IEnumerable<TipoDocumentosDto> GetTipoDocumentos()
        {
            return _mapper.Map<IEnumerable<TipoDocumentosDto>>(_tipoDocumentosRepository.GetAllTipoDocumentos());
        }
    }
}

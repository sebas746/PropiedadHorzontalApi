using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System;

namespace PropiedadHorizontal.Business.Services
{
    public class CopropietariosService : ICopropietariosService
    {
        private readonly ICopropietariosRepository _copropietariosRepository;
        private readonly IMapper _mapper;

        public CopropietariosService(ICopropietariosRepository copropietariosRepository, IMapper mapper)
        {
            _copropietariosRepository = copropietariosRepository;
            _mapper = mapper;
        }

        public CopropietariosDto GetCopropietarioById(string idDocumentoCopropietario)
        {
            try
            {
                var copropietario = _copropietariosRepository.GetCopropietarioById(idDocumentoCopropietario);
                return _mapper.Map<CopropietariosDto>(copropietario);
            }

            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public bool ExistsCopropietario(string idDocumentoCopropietario)
        {
            try
            {   
                return _copropietariosRepository.ExistsCopropietario(idDocumentoCopropietario);
            }

            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }
    }
}

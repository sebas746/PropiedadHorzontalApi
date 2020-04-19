using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropiedadHorizontal.Business.Services
{
    public class CopropietariosService : ICopropietariosService
    {
        private readonly ICopropietariosRepository _copropietariosRepository;
        private readonly ITipoCopropiedadesRepository _tipoCopropiedadesRepository;
        private readonly IMapper _mapper;
       

        public CopropietariosService(ICopropietariosRepository copropietariosRepository, IMapper mapper, ITipoCopropiedadesRepository tipoCopropiedadesRepository)
        {   
            _copropietariosRepository = copropietariosRepository;
            _tipoCopropiedadesRepository = tipoCopropiedadesRepository;
            _mapper = mapper;
        }

        public IEnumerable<CopropietariosDto> GetAllCopropietarios(PaginationDto pagination)
        {
            try
            {
                if (!GenericUtils<Copropietarios>.IsValidProperty(pagination.OrderBy, false))
                {
                    pagination.OrderBy = "NombresCopropietario";
                }

                var copropietarios = _copropietariosRepository.GetAllCopropietarios(pagination);
                

                return _mapper.Map<List<CopropietariosDto>>(copropietarios);
            }

            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
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

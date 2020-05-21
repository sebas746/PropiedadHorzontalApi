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
    public class CopropietariosService : ICopropietariosService
    {
        private readonly ICopropietariosRepository _copropietariosRepository;
        private readonly ICopropiedadesRepository _copropiedadesRepository;
        private readonly IMapper _mapper;
       

        public CopropietariosService(ICopropietariosRepository copropietariosRepository, IMapper mapper, ICopropiedadesRepository copropiedadesRepository)
        {   
            _copropietariosRepository = copropietariosRepository;
            _copropiedadesRepository = copropiedadesRepository;
            _mapper = mapper;
        }

        public IEnumerable<CopropietariosDto> GetAllCopropietarios(PaginationDto paginationDto)
        {
            try
            {
                if (!GenericUtils<Copropietarios>.IsValidProperty(paginationDto.OrderBy, false))
                {
                    paginationDto.OrderBy = "NombresCopropietario";
                }

                var pagination = _mapper.Map<Pagination>(paginationDto);

                var copropietarios = _copropietariosRepository.GetAllCopropietarios(pagination);

                foreach(var copropietario in copropietarios)
                {
                    copropietario.Copropiedades = _copropiedadesRepository.GetAllCopropiedadesCopropietario(copropietario.IdDocumentoCopropietario);
                }
                
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

        
        public CopropietariosDto UpdateCopropiedad(CopropietariosDto copropietarioDto)
        {
            try
            {
                var copropietario = _mapper.Map<Copropietarios>(copropietarioDto);
                var resultDto = _mapper.Map<CopropietariosDto>(_copropietariosRepository.UpdateCopropietario(copropietario));
                return resultDto;
            }
            catch
            {
                throw;
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

        public CopropietariosDto InsertCopropietario(Copropietarios copropietario)
        {
            try
            {
                return _mapper.Map<CopropietariosDto>(_copropietariosRepository.InsertCopropietario(copropietario));
            }

            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public bool InsertCopropietarios(List<CopropietariosDto> copropietariosDto)
        {
            var copropietarios = _mapper.Map<List<Copropietarios>>(copropietariosDto);

            foreach(var co in copropietarios)
            {
                if(!ExistsCopropietario(co.IdDocumentoCopropietario))
                {
                    _copropietariosRepository.InsertCopropietario(co);
                }
            }

            return true;
        }

        //public List<Copropiedades> CleanDuplicatedCopropietarios(List<Copropietarios> copropietarios)
        //{
        //    var cop = copropietarios.Select(co => co.IdDocumentoCopropietario).Distinct();
        //        .GroupBy(x => x)
        //        .Where(g => g.Count() > 1)
        //        .Select(y => new { Element = y.Key, Counter = y.Count() })
        //        .ToList();





        //    return false;
        //}
    }
}

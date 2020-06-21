using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using PropiedadHorizontal.Data.Utils;
using Serilog;
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
                Log.Error("Error GetAllCopropietarios: " + exc.Message);
                throw;
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
                Log.Error("Error UpdateCopropiedad: " + exc.Message);
                throw;
            }
        }

        
        public CopropietariosDto UpdateCopropiedad(string numeroDocumento, CopropietariosDto copropietarioDto)
        {
            try
            {
                CopropietariosDto resultDto = null;
                var copropietario = _mapper.Map<Copropietarios>(copropietarioDto);

                if(numeroDocumento != copropietario.IdDocumentoCopropietario)
                {
                    var copropiedadesCopropietario = _copropiedadesRepository.GetAllCopropiedadesCopropietario(numeroDocumento);
                    
                    resultDto = _mapper.Map<CopropietariosDto>(_copropietariosRepository.InsertCopropietario(copropietario));

                    foreach(var copropiedad in copropiedadesCopropietario)
                    {
                        copropiedad.IdDocumentoCopropietario = copropietario.IdDocumentoCopropietario;
                        copropiedad.Copropietario = copropietario;
                        _copropiedadesRepository.UpdateCopropiedad(copropiedad);
                    }

                    _copropietariosRepository.DeleteCopropietario(numeroDocumento);
                }

                else
                {
                    resultDto = _mapper.Map<CopropietariosDto>(_copropietariosRepository.UpdateCopropietario(copropietario));
                }
                
                return resultDto;
            }
            catch(Exception exc)
            {
                Log.Error("Error UpdateCopropiedad: " + exc.Message);
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
                Log.Error("Error UpdateCopropiedad: " + exc.Message);
                throw;
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
                Log.Error("Error InsertCopropietario: " + exc.Message);
                throw;
            }
        }

        public bool InsertCopropietarios(List<CopropietariosDto> copropietariosDto)
        {
            try
            {
                var copropietarios = _mapper.Map<List<Copropietarios>>(copropietariosDto);

                foreach (var co in copropietarios)
                {
                    if (!ExistsCopropietario(co.IdDocumentoCopropietario))
                    {
                        _copropietariosRepository.InsertCopropietario(co);
                    }
                }

                return true;
            }
            catch (Exception exc)
            {
                Log.Error("Error InsertCopropietarios: " + exc.Message);
                throw;
            }
        }

        public int Count()
        {
            try
            {
                return _copropietariosRepository.Count();
            }
            catch (Exception exc)
            {
                Log.Error("Error Count Copropietarios: " + exc.Message);
                throw;
            }
        }
    }
}

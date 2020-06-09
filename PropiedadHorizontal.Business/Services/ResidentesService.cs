using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using PropiedadHorizontal.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropiedadHorizontal.Business.Services
{
    public class ResidentesService : IResidentesService
    {
        private readonly IMapper _mapper;
        private readonly IResidentesRepository _residentesRepository;

        public ResidentesService(IResidentesRepository residentesRepository, IMapper mapper)
        {
            _residentesRepository = residentesRepository;
            _mapper = mapper;
        }

        public IEnumerable<ResidentesDto> GetAllResidentes(PaginationDto paginationDto)
        {
            try
            {
                if (!GenericUtils<Residentes>.IsValidProperty(paginationDto.OrderBy, false))
                {
                    paginationDto.OrderBy = "NombresResidente";
                }

                var pagination = _mapper.Map<Pagination>(paginationDto);

                var residentes = _residentesRepository.GetAllResidentes(pagination);

                return _mapper.Map<List<ResidentesDto>>(residentes);
            }

            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        public bool CreateResidentes(List<CopropiedadesDto> copropiedadesDto)
        {
            try
            {
                foreach(var co in copropiedadesDto)
                {
                    if(co.EsResidenteCopropietario.Value)
                    {
                        co.Residente.ApellidosResidente = co.Copropietario.ApellidosCopropietario;
                        co.Residente.CelularResidente = co.Copropietario.CelularCopropietario;
                        co.Residente.CodigoTipoDocumentoResidente = co.Copropietario.CodigoTipoDocumentoCopropietario;
                    }
                }
                return true;
            }
            catch
            {
                throw;
            }
            
        }

        ///<see cref="IResidentesService.UpdateResidente(Residentes)"/>
        public bool UpdateResidente(Residentes residente)
        {
            try
            {
                if (residente != null)
                {
                    if(!IsValidResidente(residente))
                    {
                        return false;
                    }

                    if (!_residentesRepository.ExistsResidente(residente.IdDocumentoResidente))
                    {
                        _residentesRepository.InsertResidente(residente);
                    }
                    else
                    {
                        _residentesRepository.UpdateResidente(residente);
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }

        private bool IsValidResidente(Residentes residente)
        {

            if(string.IsNullOrEmpty(residente.IdDocumentoResidente) || string.IsNullOrEmpty(residente.CodigoTipoDocumentoResidente) || string.IsNullOrEmpty(residente.NombresResidente)
                || string.IsNullOrEmpty(residente.ApellidosResidente))
            {
                return false;
            }

            return true;
        }
    }
}

using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;

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

        ///<see cref="IResidentesService.UpdateResidente(Residentes)"/>
        public bool UpdateResidente(Residentes residente)
        {
            try
            {
                if (residente != null)
                {
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
    }
}

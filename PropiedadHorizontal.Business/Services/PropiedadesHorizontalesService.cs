
using AutoMapper;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Business.Utils;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PropiedadHorizontal.Business.Services
{
    public class PropiedadesHorizontalesService : IPropiedadesHorizontalesService
    {
        private readonly IPropiedadesHorizontalesRepository _propiedadesHorizontalesRepository;
        private readonly IMapper _mapper;

        public PropiedadesHorizontalesService(IPropiedadesHorizontalesRepository propiedadesHorizontalesRepository
             , IMapper mapper)
        {
            _propiedadesHorizontalesRepository = propiedadesHorizontalesRepository;
            _mapper = mapper;
        }

        public IEnumerable<PropiedadHorizontalDto> GetAllPropiedadesHorizontales(int skip, int take, string searchString, string sortOrder, string currentSort)
        {
            try
            {
                if(!GenericUtils<PropiedadesHorizontales>.IsValidProperty(currentSort, false))
                {
                    currentSort = "NombrePropiedadHorizontal";
                }

                var propiedades = _propiedadesHorizontalesRepository.GetAllPropiedadesHorizontales(skip, take, searchString, sortOrder, currentSort);

                if (propiedades != null)
                {
                    var propiedadesDTO = propiedades.Select(
                            ph => new PropiedadHorizontalDto
                            {
                                Direccion = ph.DireccionPropiedadHorizontal,
                                Email = ph.EmailPropiedadHorizontal,
                                Logo = ph.LogoPropiedadHorizontal,
                                NitPropiedadHorizontal = ph.NitPropiedadHorizontal,
                                NombrePropiedadHorizontal = ph.NombrePropiedadHorizontal,
                                NombreMunicipio = ph.Municipio == null ? "" : ph.Municipio.NombreMunicipio,
                                Telefono = ph.TelefonoPropiedadHorizontal
                            }

                        );

                    return propiedadesDTO.ToList();
                }

                return new List<PropiedadHorizontalDto>();
            }
            catch (Exception exc)
            {
                Log.Error("Error GetAllPropiedadesHorizontales: " + exc.Message);
                throw;
            }
        }

        public InfoGeneralCopropiedadesDto GetInformacionCopropiedades(string nitPropiedadHorizontal)
        {
            try
            {
                var response = _mapper.Map<InfoGeneralCopropiedadesDto>(_propiedadesHorizontalesRepository.GetInformacionCopropiedades(nitPropiedadHorizontal));

                if (response.SumatoriaCoeficientes > 100 || response.SumatoriaCoeficientes < 99)
                {
                    response.IsPropiedadHorizontalCompleted = false;
                    response.PropiedadHorizontaMessage = "Por favor verifique las copropiedades";
                }
                else
                {
                    response.IsPropiedadHorizontalCompleted = true;
                    response.PropiedadHorizontaMessage = "Copropiedades correctamente diligenciadas";
                }

                return response;
            }
            catch (Exception exc)
            {
                Log.Error("Error GetInformacionCopropiedades: " + exc.Message);
                throw;
            }
        }
    }
}


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
    public class PropiedadesHorizontalesService : IPropiedadesHorizontalesService
    {
        private readonly IPropiedadesHorizontalesRepository _propiedadesHorizontalesRepository;

        public PropiedadesHorizontalesService(IPropiedadesHorizontalesRepository propiedadesHorizontalesRepository)
        {
            _propiedadesHorizontalesRepository = propiedadesHorizontalesRepository;
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

            catch
            {
                throw;
            }
        }
    }
}

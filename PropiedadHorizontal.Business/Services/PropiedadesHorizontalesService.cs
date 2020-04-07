
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Repositories.Interfaces;
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
                var propiedades = _propiedadesHorizontalesRepository.GetAllPropiedadesHorizontales(skip, take, searchString, sortOrder, currentSort);

                if (propiedades != null)
                {
                    var propiedadesDTO = propiedades.Select(
                            ph => new PropiedadHorizontalDto
                            {
                                Direccion = ph.Direccion,
                                Email = ph.Email,
                                Logo = ph.Logo,
                                Nit = ph.Nit,
                                Nombre = ph.Nombre,
                                NombreMunicipio = ph.Municipio == null ? "" : ph.Municipio.Nombre,
                                Telefono = ph.Telefono
                            }

                        );

                    return propiedadesDTO.ToList();
                }

                return new List<PropiedadHorizontalDto>();
            }

            catch
            {
                return null;
            }
        }
    }
}

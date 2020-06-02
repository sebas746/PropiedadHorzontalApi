
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface IPropiedadesHorizontalesService
    {
        IEnumerable<PropiedadHorizontalDto> GetAllPropiedadesHorizontales(int skip, int take, string searchString, string sortOrder, string currentSort);
        InfoGeneralCopropiedadesDto GetInformacionCopropiedades(string nitPropiedadHorizontal);
    }
}

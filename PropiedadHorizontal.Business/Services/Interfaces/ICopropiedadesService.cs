
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropiedadesService
    {
        IEnumerable<CopropiedadesDto> GetAllCopropiedades(PaginationDto pagination);
    }
}

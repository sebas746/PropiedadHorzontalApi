
using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface ICopropiedadesRepository
    {
        /// <summary>
        /// Get Copropiedades.
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns></returns>
        IEnumerable<Copropiedades> GetAllCopropiedades(PaginationDto pagination);

        /// <summary>
        /// Create a new Copropiedad.
        /// </summary>
        /// <param name="copropiedad"></param>
        /// <returns></returns>
        Copropiedades InsertCopropiedad(Copropiedades copropiedad);
    }
}

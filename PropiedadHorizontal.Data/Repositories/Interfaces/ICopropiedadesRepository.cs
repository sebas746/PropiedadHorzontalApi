
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

        /// <summary>
        /// Get a copropiedad by id.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns></returns>
        Copropiedades GetCopropiedadById(int copropiedadId);

        /// <summary>
        /// Deletes a copropiedad.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns>
        /// True: If copropiedad was deleted.
        /// False: If copropiedad was NOT deleted.
        /// </returns>
        bool DeleteCopropiedad(int copropiedadId);

        /// <summary>
        /// Update a copropiedad.
        /// </summary>
        /// <param name="copropiedad">Copropiedad id.</param>
        /// <returns>Copropiedad updated object.</returns>
        Copropiedades UpdateCopropiedad(Copropiedades copropiedad);

        bool ExistsCopropiedadNombre(string copropiedadNombre);
    }
}

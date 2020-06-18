
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Utils;
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
        IEnumerable<Copropiedades> GetAllCopropiedades(Pagination pagination);

        /// <summary>
        /// Get all copropiedades from a copropietario.
        /// </summary>
        /// <param name="idDocumentoCopropietario">Id documento copropietario.</param>
        /// <returns></returns>
        ICollection<Copropiedades> GetAllCopropiedadesCopropietario(string idDocumentoCopropietario);

        /// <summary>
        /// Create a new Copropiedad.
        /// </summary>
        /// <param name="copropiedad"></param>
        /// <returns></returns>
        Copropiedades InsertCopropiedad(Copropiedades copropiedad);

        /// <summary>
        /// Bulk copropietarios insert.
        /// </summary>
        /// <param name="copropiedades">Copropiedades List.</param>
        /// <returns>
        /// True: In case successful save.
        /// False: In case error save.
        /// </returns>
        bool InsertBulkCopropiedades(List<Copropiedades> copropiedades);

        /// <summary>
        /// Get a copropiedad by id.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns></returns>
        Copropiedades GetCopropiedadById(long copropiedadId);

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

        bool ExistsCopropiedadNombre(string copropiedadNombre, int idCopropiedad);

        /// <summary>
        /// Get non existent copropiedades in database.
        /// </summary>
        /// <param name="copropiedadesList">Copropiedades list.</param>
        /// <param name="nitCopropiedad">Nit Copropiedad.</param>
        /// <returns></returns>
        ICollection<Copropiedades> GetNonExistentCopropiedades(ICollection<Copropiedades> copropiedadesList, string nitCopropiedad);

        /// <summary>
        /// Get the copropiedades associated to a residente
        /// </summary>
        /// <param name="idDocumentoResidente">Id documento residente.</param>
        /// <returns></returns>
        IEnumerable<Copropiedades> GetCopropiedadesResidente(string idDocumentoResidente);
        int Count();
    }
}

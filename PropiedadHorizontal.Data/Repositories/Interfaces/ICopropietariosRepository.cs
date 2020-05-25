using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface ICopropietariosRepository
    {
        /// <summary>
        /// Get copropietarios.
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns></returns>
        IEnumerable<Copropietarios> GetAllCopropietarios(Pagination pagination);

        /// <summary>
        /// Get a copropietario by id Documento
        /// </summary>
        /// <param name="idDocumentoCopropietario">Id documento</param>
        /// <returns>
        /// Copropietario object.
        /// </returns>
        Copropietarios GetCopropietarioById(string idDocumentoCopropietario);

        /// <summary>
        /// Update an existent copropietario.
        /// </summary>
        /// <param name="copropietario">Copropietario object.</param>
        /// <returns></returns>
        Copropietarios UpdateCopropietario(Copropietarios copropietario);

        /// <summary>
        /// Delete an existent copropietario.
        /// </summary>
        /// <param name="idDocumentocopropiedatario"></param>
        /// <returns></returns>
        bool DeleteCopropietario(string idDocumentocopropiedatario);

        /// <summary>
        /// Check if exists a copropietario.
        /// </summary>
        /// <param name="idDocumentoCopropietario">Id documento.</param>
        /// <returns>
        /// true: if exists.
        /// false: if NOT exists.
        /// </returns>
        bool ExistsCopropietario(string idDocumentoCopropietario);

        /// <summary>
        /// Insert a new copropietario
        /// </summary>
        /// <param name="copropietario">Copropietario model object.</param>
        /// <returns></returns>
        Copropietarios InsertCopropietario(Copropietarios copropietario);

        Task<bool> InsertBulkCopropietarios(List<Copropietarios> copropietarios);

        ICollection<Copropietarios> GetNonExistentCopropietarios(ICollection<Copropietarios> copropietariosList, string nitCopropiedad);
        int Count();
    }
}

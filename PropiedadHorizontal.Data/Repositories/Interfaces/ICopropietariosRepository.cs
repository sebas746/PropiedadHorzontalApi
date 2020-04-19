using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface ICopropietariosRepository
    {
        /// <summary>
        /// Get copropietarios.
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns></returns>
        IEnumerable<Copropietarios> GetAllCopropietarios(PaginationDto pagination);

        /// <summary>
        /// Get a copropietario by id Documento
        /// </summary>
        /// <param name="idDocumentoCopropietario">Id documento</param>
        /// <returns>
        /// Copropietario object.
        /// </returns>
        Copropietarios GetCopropietarioById(string idDocumentoCopropietario);

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
    }
}

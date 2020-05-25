using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Utils;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface IItemsComunesRepository
    {
        /// <summary>
        /// Method to get all items comunes based on pagination.
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>List of items.</returns>
        IEnumerable<ItemsComunes> GetAllItemsComunes(Pagination pagination);

        /// <summary>
        /// Get items comunes based on a codigo agrupador.
        /// </summary>
        /// <param name="codigoAgrupador">Codigo agrupador name.</param>
        /// <returns>List of items.</returns>
        ICollection<ItemsComunes> GetItemsComunesByCodigoAgrupador(string codigoAgrupador);

        /// <summary>
        /// Get all the items comunes.
        /// </summary>
        /// <returns>List of items.</returns>
        IEnumerable<ItemsComunes> GetAllItemsComunes();

        /// <summary>
        /// Look for the items comunes that contains the nombre agrupador.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>List of items.</returns>
        ICollection<ItemsComunes> GetItemsComunesByNombreAgrupador(string filter);
    }
}

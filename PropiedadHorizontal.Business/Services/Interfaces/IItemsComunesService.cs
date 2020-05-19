using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface IItemsComunesService
    {
        /// <summary>
        /// Get items comunes based on a codigo agrupador.
        /// </summary>
        /// <param name="codigoAgrupador">Codigo agrupador name.</param>
        /// <returns>List of items.</returns>
        ICollection<ItemsComunesDto> GetItemsComunesByCodigoAgrupador(string codigoAgrupador);

        IEnumerable<ItemsComunesDto> GetAllItemsComunes();
    }
}

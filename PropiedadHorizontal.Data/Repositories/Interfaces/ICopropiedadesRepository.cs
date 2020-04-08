
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface ICopropiedadesRepository
    {
        /// <summary>
        /// Get copropiedades.
        /// </summary>
        /// <param name="skip">Skip copropiedades</param>
        /// <param name="take">Number of copropiedades</param>
        /// <param name="searchString">Search string</param>
        /// <param name="sortOrder">ASC or DESC</param>
        /// <param name="currentSort">Sorter</param>
        /// <returns></returns>
        IEnumerable<Copropiedades> GetAllCopropiedades(int skip, int take, string searchString, string sortOrder, string currentSort);
    }
}

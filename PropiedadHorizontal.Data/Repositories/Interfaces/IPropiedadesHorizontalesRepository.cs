using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface IPropiedadesHorizontalesRepository
    {
        // <summary>
        /// Get Propiedades Horizontales By Ids
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="driversIds"></param>
        /// <returns></returns>
        IEnumerable<PropiedadesHorizontales> GetPropiedadesHorizontalesByNombres(int skip, int take, string[] propiedadesHorizontalesNombres);

        /// <summary>
        /// Get All Propiedades horizontales
        /// </summary>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <param name="searchString"></param>
        /// <param name="sortOrder"></param>
        /// <param name="currentSort"></param>
        /// <returns></returns>
        IEnumerable<PropiedadesHorizontales> GetAllPropiedadesHorizontales(int skip, int take, string searchString, string sortOrder, string currentSort);
    }
}


using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PropiedadHorizontal.Data.Repositories
{
    public class PropiedadesHorizontalesRepository : GenericRepository<PropiedadesHorizontales>, IPropiedadesHorizontalesRepository
    {
        private readonly Expression<Func<PropiedadesHorizontales, bool>> EmptyFilter = ph => ph.NitPropiedadHorizontal != "";
        public PropiedadesHorizontalesRepository(IBaseContext context) : base(context)
        {
        }

        ///<see cref="IPropiedadesHorizontalesRepository.GetPropiedadesHorizontalesByNombres(int, int, string[])"/>
        public IEnumerable<PropiedadesHorizontales> GetPropiedadesHorizontalesByNombres(int skip, int take, string[] propiedadesHorizontalesNombres)
        {
            var defaultSorter = Utils.Utils.OrderByFunc<PropiedadesHorizontales>("Nombre");
            var propiedadesHorizontales = GetQueryable(skip, take, ph => propiedadesHorizontalesNombres.Contains(ph.Nombre.ToString()), defaultSorter);
            return propiedadesHorizontales;
        }

        ///<see cref="IPropiedadesHorizontalesRepository.GetAllPropiedadesHorizontales(int, int, string, string[], string, string)"/>
        public IEnumerable<PropiedadesHorizontales> GetAllPropiedadesHorizontales(int skip, int take, string searchString, string sortOrder, string currentSort)
        {
            var sorter = Utils.Utils.OrderByFunc<PropiedadesHorizontales>(currentSort, string.IsNullOrEmpty(sortOrder)
                                                                               || sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var sorterList = new List<Func<IQueryable<PropiedadesHorizontales>, IOrderedQueryable<PropiedadesHorizontales>>>();
            if (currentSort != null && !currentSort.Equals("Nombre"))
            {
                //Default second sorter
                var defaultSorter = Utils.Utils.OrderByFunc<PropiedadesHorizontales>("Nit");
                sorterList.Add(defaultSorter);
            }

            sorterList.Add(sorter);

            var includes = new Expression<Func<PropiedadesHorizontales, object>>[] { ph => ph.Municipio };

            var propiedades = GetPaginated(skip, take,
                                      !string.IsNullOrEmpty(searchString) ?
                                      (dr => dr.NitPropiedadHorizontal != "" &&
                                             (dr.Email.Contains(searchString, StringComparison.CurrentCultureIgnoreCase) ||
                                              dr.Nombre.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)))
                                      : EmptyFilter,
                                      sorterList, includes);
            return propiedades;
        }
    }
}

using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PropiedadHorizontal.Data.Repositories
{
    public class CopropiedadesRepository : GenericRepository<Copropiedades>, ICopropiedadesRepository
    {
        private readonly Expression<Func<Copropiedades, bool>> EmptyFilter = ph => ph.Nombre != "";
        public CopropiedadesRepository(IBaseContext context) : base(context)
        {
        }

        ///<see cref="ICopropiedadesRepository.GetAllPropiedadesHorizontales(int, int, string, string, string)"/>
        public IEnumerable<Copropiedades> GetAllCopropiedades(int skip, int take, string searchString, string sortOrder, string currentSort)
        {
            var sorter = Utils.Utils.OrderByFunc<Copropiedades>(currentSort, string.IsNullOrEmpty(sortOrder)
                                                                               || sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var sorterList = new List<Func<IQueryable<Copropiedades>, IOrderedQueryable<Copropiedades>>>();
            if (currentSort != null && !currentSort.ToUpper().Equals("NOMBRE"))
            {
                //Default second sorter
                var defaultSorter = Utils.Utils.OrderByFunc<Copropiedades>("IdCopropiedad");
                sorterList.Add(defaultSorter);
            }

            sorterList.Add(sorter);

            var includes = new Expression<Func<Copropiedades, object>>[] {  };

            var copropiedades = GetPaginated(skip, take,
                                      !string.IsNullOrEmpty(searchString) ?
                                      (co => co.IdCopropiedad != 0 &&
                                             (co.Nombre.Contains(searchString, StringComparison.CurrentCultureIgnoreCase)))
                                      : EmptyFilter,
                                      sorterList, includes);
            return copropiedades;
        }
    }
}

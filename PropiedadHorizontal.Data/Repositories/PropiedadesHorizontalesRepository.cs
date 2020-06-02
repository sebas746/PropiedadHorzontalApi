
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
        private readonly ApplicationDbContext _generalContext;
        public PropiedadesHorizontalesRepository(IBaseContext context, ApplicationDbContext generalContext) : base(context)
        {
            _generalContext = generalContext;
        }

        ///<see cref="IPropiedadesHorizontalesRepository.GetPropiedadesHorizontalesByNombres(int, int, string[])"/>
        public IEnumerable<PropiedadesHorizontales> GetPropiedadesHorizontalesByNombres(int skip, int take, string[] propiedadesHorizontalesNombres)
        {
            var defaultSorter = Utils.Utils.OrderByFunc<PropiedadesHorizontales>("Nombre");
            var propiedadesHorizontales = GetQueryable(skip, take, ph => propiedadesHorizontalesNombres.Contains(ph.NombrePropiedadHorizontal.ToString()), defaultSorter);
            return propiedadesHorizontales;
        }

        ///<see cref="IPropiedadesHorizontalesRepository.GetAllPropiedadesHorizontales(int, int, string, string[], string, string)"/>
        public IEnumerable<PropiedadesHorizontales> GetAllPropiedadesHorizontales(int skip, int take, string searchString, string sortOrder, string currentSort)
        {
            var sorter = Utils.Utils.OrderByFunc<PropiedadesHorizontales>(currentSort, string.IsNullOrEmpty(sortOrder)
                                                                               || sortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var includes = new Expression<Func<PropiedadesHorizontales, object>>[] { ph => ph.Municipio };

            var propiedades = GetPaginated(skip, take,
                                      !string.IsNullOrEmpty(searchString) ?
                                      (dr => dr.NitPropiedadHorizontal != "" &&
                                             (dr.EmailPropiedadHorizontal.Contains(searchString) ||
                                              dr.NombrePropiedadHorizontal.Contains(searchString)))
                                      : EmptyFilter,
                                      sorter, includes);
            return propiedades;
        }

        public InfoGeneralCopropiedades GetInformacionCopropiedades(string nitPropiedadHorizontal)
        {
            var copropiedadesInfo = _generalContext.Copropiedades.Where(co => co.NitPropiedadHorizontal.Equals(nitPropiedadHorizontal))
                            .Select(res => 
                                new InfoGeneralCopropiedades()
                                {
                                    SumatoriaAreasPrivadas = res.AreaCopropiedad,
                                    SumatoriaCoeficientes = res.CoeficienteCopropiedad
                                }
                            );

            var result = new InfoGeneralCopropiedades()
            {
                SumatoriaAreasPrivadas = copropiedadesInfo.Sum(co => co.SumatoriaAreasPrivadas),
                SumatoriaCoeficientes = copropiedadesInfo.Sum(co => co.SumatoriaCoeficientes),
            };


            return result;
        }
    }
}

using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using PropiedadHorizontal.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PropiedadHorizontal.Data.Repositories
{
    public class ItemsComunesRepository : GenericRepository<ItemsComunes>, IItemsComunesRepository
    {
        private readonly Expression<Func<ItemsComunes, bool>> EmptyFilter = ic => ic.CodigoItem != "";
        private readonly ApplicationDbContext _generalContext;

        public ItemsComunesRepository(IBaseContext context, ApplicationDbContext generalContext) : base(context)
        {
            _generalContext = generalContext;
        }

        ///<see cref="IItemsComunesRepository.GetAllItemsComunes(Pagination)"/>
        public IEnumerable<ItemsComunes> GetAllItemsComunes(Pagination pagination)
        {
            var sorter = Utils.Utils.OrderByFunc<ItemsComunes>(pagination.OrderBy, string.IsNullOrEmpty(pagination.SortOrder)
                                                                               || pagination.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var take = pagination.PageSize;

            var includes = new Expression<Func<ItemsComunes, object>>[] { };

            var items = GetPaginated(pagination.Skip, take,
                                      !string.IsNullOrEmpty(pagination.Filter) ?
                                      (ic => ic.CodigoItem != "" &&
                                      (ic.CodigoItem.Contains(pagination.Filter) ||
                                      (ic.NombreItem.Contains(pagination.Filter))))
                                      : EmptyFilter,
                                      sorter, includes);

            return items;
        }

        ///<see cref="IItemsComunesRepository.GetAllItemsComunes"/>
        public IEnumerable<ItemsComunes> GetAllItemsComunes()
        {
            return _generalContext.ItemsComunes.ToList();
        }

        ///<see cref="IItemsComunesRepository.GetItemsComunesByCodigoAgrupador(string)"/>
        public ICollection<ItemsComunes> GetItemsComunesByCodigoAgrupador(string codigoAgrupador)
        {
            return _generalContext.ItemsComunes.Where(ic => ic.CodigoAgrupador.Equals(codigoAgrupador)).ToList();
        }
    }
}

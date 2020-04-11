using Microsoft.EntityFrameworkCore;
using PropiedadHorizontal.Core.DTO;
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
        private readonly Expression<Func<Copropiedades, bool>> EmptyFilter = ph => ph.NombreCopropiedad != "";
        public CopropiedadesRepository(IBaseContext context) : base(context)
        {
        }

        ///<see cref="ICopropiedadesRepository.GetAllCopropiedades(PaginationDto)"/>
        public IEnumerable<Copropiedades> GetAllCopropiedades(PaginationDto pagination)
        {
            var sorter = Utils.Utils.OrderByFunc<Copropiedades>(pagination.OrderBy, string.IsNullOrEmpty(pagination.SortOrder)
                                                                               || pagination.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));
            
            var sorterList = new List<Func<IQueryable<Copropiedades>, IOrderedQueryable<Copropiedades>>>();

            if (pagination.OrderBy != null && !pagination.OrderBy.Equals("NombreCopropiedad"))
            {
                //Default second sorter
                var defaultSorter = Utils.Utils.OrderByFunc<Copropiedades>("IdCopropiedad");
                sorterList.Add(defaultSorter);
            }

            sorterList.Add(sorter);

            var skip = (pagination.PageNumber) * pagination.PageSize;
            var take = pagination.PageSize;

            var includes = new Expression<Func<Copropiedades, object>>[] { co => co.PropiedadHorizontal, co => co.TipoCopropiedad, co => co.Copropietario };

            var copropiedades = GetPaginated(skip, take,
                                      !string.IsNullOrEmpty(pagination.Filter) ?
                                      (co => co.IdCopropiedad != 0 &&
                                             (co.NombreCopropiedad.Contains(pagination.Filter, StringComparison.CurrentCultureIgnoreCase)))
                                      : EmptyFilter,
                                      sorterList, includes);
            return copropiedades;
        }

        ///<see cref="ICopropiedadesRepository.InsertCopropiedad(Copropiedades)"/>
        public Copropiedades InsertCopropiedad(Copropiedades copropiedad)
        {
            base.Insert(copropiedad);
            _context.SaveChanges();
            return copropiedad;
        }

        ///<see cref="ICopropiedadesRepository.GetCopropiedadById(int)"/>
        public Copropiedades GetCopropiedadById(int copropiedadId)
        {
            var includes = new Expression<Func<Copropiedades, object>>[] { co => co.PropiedadHorizontal, co => co.TipoCopropiedad, co => co.Copropietario };
            return Get(co => co.IdCopropiedad.Equals(copropiedadId), includes: includes).FirstOrDefault();
        }

        ///<see cref="ICopropiedadesRepository.UpdateCopropiedad(Copropiedades)"/>
        public Copropiedades UpdateCopropiedad(Copropiedades copropiedad)
        {
            base.Update(copropiedad);
            _context.SaveChanges();
            return copropiedad;
        }

        ///<see cref="ICopropiedadesRepository.DeleteCopropiedad(int)"/>
        public bool DeleteCopropiedad(int copropiedadId)
        {
            base.Delete(copropiedadId);
            _context.SaveChanges();
            return true;
        }
    }
}

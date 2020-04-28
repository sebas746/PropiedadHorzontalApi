﻿using Microsoft.EntityFrameworkCore;
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
    public class CopropiedadesRepository : GenericRepository<Copropiedades>, ICopropiedadesRepository
    {
        private readonly Expression<Func<Copropiedades, bool>> EmptyFilter = ph => ph.NombreCopropiedad != "";
        private readonly ApplicationDbContext _generalContext;
        public CopropiedadesRepository(IBaseContext context, ApplicationDbContext generalContext) : base(context)
        {
            _generalContext = generalContext;
        }

        ///<see cref="ICopropiedadesRepository.GetAllCopropiedades(Pagination)"/>
        public IEnumerable<Copropiedades> GetAllCopropiedades(Pagination pagination)
        {
            var sorter = Utils.Utils.OrderByFunc<Copropiedades>(pagination.OrderBy, string.IsNullOrEmpty(pagination.SortOrder)
                                                                               || pagination.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));
            
            var take = pagination.PageSize;

            var includes = new Expression<Func<Copropiedades, object>>[] { co => co.PropiedadHorizontal, co => co.TipoCopropiedad, co => co.Copropietario };

            var copropiedades = GetPaginated(pagination.Skip, take,
                                      !string.IsNullOrEmpty(pagination.Filter) ?
                                      (co => co.IdCopropiedad != 0 &&
                                            (co.TipoCopropiedad.DescripcionTipoCopropiedad.Contains(pagination.Filter)) ||
                                            (co.Copropietario.NombresCopropietario + " " + co.Copropietario.ApellidosCopropietario).Contains(pagination.Filter) ||
                                            (co.NombreCopropiedad.Contains(pagination.Filter)))
                                      : EmptyFilter,
                                      sorter, includes);
            return copropiedades;
        }

        ///<see cref="ICopropiedadesRepository.GetAllCopropiedadesCopropietario(string)"/>
        public ICollection<Copropiedades> GetAllCopropiedadesCopropietario(string idDocumentoCopropietario)
        {
            return _generalContext.Copropiedades.Include(co => co.TipoCopropiedad).Where(co => co.IdDocumentoCopropietario.Equals(idDocumentoCopropietario)).ToList();
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
            var includes = new Expression<Func<Copropiedades, object>>[] { co => co.PropiedadHorizontal, co => co.TipoCopropiedad, co => co.Copropietario, co => co.Residente };
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

        public bool ExistsCopropiedadNombre(string copropiedadNombre, int idCopropiedad)
        {
            return _generalContext.Copropiedades.Any(co => co.NombreCopropiedad.ToUpper().Equals(copropiedadNombre.ToUpper())
                && co.IdCopropiedad != idCopropiedad);
        }
    }
}

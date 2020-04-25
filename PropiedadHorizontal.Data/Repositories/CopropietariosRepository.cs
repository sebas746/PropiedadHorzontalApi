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
    public class CopropietariosRepository : GenericRepository<Copropietarios>, ICopropietariosRepository
    {
        private readonly Expression<Func<Copropietarios, bool>> EmptyFilter = co => co.NombresCopropietario != "";
        private readonly ApplicationDbContext _generalContext;

        public CopropietariosRepository(IBaseContext context, ApplicationDbContext generalContext) : base(context)
        {
            _generalContext = generalContext;
        }

        ///<see cref="ICopropietariosRepository.GetAllCopropietarios(PaginationDto)"/>
        public IEnumerable<Copropietarios> GetAllCopropietarios(PaginationDto pagination)
        {
            var sorter = Utils.Utils.OrderByFunc<Copropietarios>(pagination.OrderBy, string.IsNullOrEmpty(pagination.SortOrder)
                                                                               || pagination.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var take = pagination.PageSize;

            var includes = new Expression<Func<Copropietarios, object>>[] { co => co.Copropiedades, co => co.TipoDocumento };

            var copropietarios = GetPaginated(pagination.Skip, take,
                                      !string.IsNullOrEmpty(pagination.Filter) ?
                                      (co => co.IdDocumentoCopropietario != "" &&
                                      (co.NombresCopropietario + " " + co.ApellidosCopropietario).Contains(pagination.Filter) ||
                                      (co.IdDocumentoCopropietario.Contains(pagination.Filter)))
                                      : EmptyFilter,
                                      sorter, includes);

            return copropietarios;
        }

        ///<see cref="ICopropietariosRepository.InsertCopropietario(Copropietarios)"/>
        public Copropietarios InsertCopropietario(Copropietarios copropietario)
        {
            base.Insert(copropietario);
            _context.SaveChanges();
            return copropietario;
        }

        ///<see cref="ICopropietariosRepository.UpdateCopropietario(Copropietarios)"/>
        public Copropietarios UpdateCopropietario(Copropietarios copropietario)
        {
            base.Update(copropietario);
            _context.SaveChanges();
            return copropietario;
        }

        ///<see cref="ICopropietariosRepository.DeleteCopropietario(string)"/>
        public bool DeleteCopropietario(string idDocumentocopropiedatario)
        {
            base.Delete(idDocumentocopropiedatario);
            _context.SaveChanges();
            return true;
        }

        ///<see cref="ICopropietariosRepository.GetCopropietarioById(string)"/>
        public Copropietarios GetCopropietarioById(string idDocumentoCopropietario)
        {
            var includes = new Expression<Func<Copropietarios, object>>[] { co => co.TipoDocumento, co => co.Copropiedades };
            return Get(co => co.IdDocumentoCopropietario.Equals(idDocumentoCopropietario), includes: includes).FirstOrDefault();
        }

        ///<see cref="ICopropietariosRepository.ExistsCopropietario(string)"/>
        public bool ExistsCopropietario(string idDocumentoCopropietario)
        {
            return _generalContext.Copropietarios.Any(co => co.IdDocumentoCopropietario.Equals(idDocumentoCopropietario));
        }
    }
}

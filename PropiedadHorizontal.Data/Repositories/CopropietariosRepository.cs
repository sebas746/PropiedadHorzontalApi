using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PropiedadHorizontal.Data.Repositories
{
    public class CopropietariosRepository : GenericRepository<Copropietarios>, ICopropietariosRepository
    {
        private readonly Expression<Func<Copropietarios, bool>> EmptyFilter = co => co.NombresCopropietario != "";
        private readonly PropiedadHorizontalContext _generalContext;

        public CopropietariosRepository(IBaseContext context, PropiedadHorizontalContext generalContext) : base(context)
        {
            _generalContext = generalContext;
        }

        ///<see cref="ICopropietariosRepository.InsertCopropietario(Copropietarios)"/>
        public Copropietarios InsertCopropietario(Copropietarios copropietario)
        {
            base.Insert(copropietario);
            _context.SaveChanges();
            return copropietario;
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

using Microsoft.EntityFrameworkCore;
using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using PropiedadHorizontal.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PropiedadHorizontal.Data.Repositories
{
    public class CopropietariosRepository : GenericRepository<Copropietarios>, ICopropietariosRepository
    {
        private readonly Expression<Func<Copropietarios, bool>> EmptyFilter = co => co.NombresCopropietario != "";
        private readonly ApplicationDbContext _generalContext;
        private readonly IItemsComunesRepository _itemsComunesRepository;

        public CopropietariosRepository(IBaseContext context
            , ApplicationDbContext generalContext
            , IItemsComunesRepository itemsComunesRepository) : base(context)
        {
            _generalContext = generalContext;
            _itemsComunesRepository = itemsComunesRepository;
        }

        ///<see cref="ICopropietariosRepository.GetAllCopropietarios(Pagination)"/>
        public IEnumerable<Copropietarios> GetAllCopropietarios(Pagination pagination)
        {
            var sorter = Utils.Utils.OrderByFunc<Copropietarios>(pagination.OrderBy, string.IsNullOrEmpty(pagination.SortOrder)
                                                                               || pagination.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var itemsComunes = _itemsComunesRepository.GetItemsComunesByNombreAgrupador(pagination.Filter).Select(ic => ic.CodigoItem).ToList();

            var includes = new Expression<Func<Copropietarios, object>>[] { co => co.Copropiedades };

            var copropietarios = GetPaginated(pagination.Skip, pagination.PageSize,
                                      !string.IsNullOrEmpty(pagination.Filter) ?
                                      (co => co.IdDocumentoCopropietario != "" &&
                                      (co.NombresCopropietario + " " + co.ApellidosCopropietario).Contains(pagination.Filter) ||
                                      (itemsComunes.Contains(co.CodigoTipoDocumentoCopropietario)) ||
                                      (co.CelularCopropietario.Contains(pagination.Filter)) ||
                                      (co.EmailCopropietario.Contains(pagination.Filter)) ||
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

        public async Task<bool> InsertBulkCopropietarios(List<Copropietarios> copropietarios)
        {   
            await _generalContext.AddRangeAsync(copropietarios);
            await _generalContext.SaveChangesAsync();
           
            return true;
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
            var includes = new Expression<Func<Copropietarios, object>>[] { co => co.Copropiedades };
            return Get(co => co.IdDocumentoCopropietario.Equals(idDocumentoCopropietario), includes: includes).FirstOrDefault();
        }

        ///<see cref="ICopropietariosRepository.ExistsCopropietario(string)"/>
        public bool ExistsCopropietario(string idDocumentoCopropietario)
        {
            return _generalContext.Copropietarios.Any(co => co.IdDocumentoCopropietario.Equals(idDocumentoCopropietario));
        }

        public ICollection<Copropietarios> GetNonExistentCopropietarios(ICollection<Copropietarios> copropietariosList, string nitCopropiedad)
        {
            var idsCopropietarios = copropietariosList.Select(co => co.IdDocumentoCopropietario).ToList();
            var existent = _generalContext.Copropietarios.Where(co => idsCopropietarios.Contains(co.IdDocumentoCopropietario))
                .Select(co => co.IdDocumentoCopropietario).ToList();

            return copropietariosList.Where(co => !existent.Contains(co.IdDocumentoCopropietario)).ToList();
        }

        public int Count()
        {
            return _generalContext.Copropietarios.Count();
        }
    }
}

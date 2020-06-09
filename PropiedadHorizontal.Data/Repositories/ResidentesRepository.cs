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
    public class ResidentesRepository : GenericRepository<Residentes>, IResidentesRepository
    {
        private readonly Expression<Func<Residentes, bool>> EmptyFilter = re => re.NombresResidente != "";
        private readonly ApplicationDbContext _generalContext;

        public ResidentesRepository(IBaseContext context, ApplicationDbContext generalContext) : base(context)
        {
            _generalContext = generalContext;
        }

        ///<see cref="IResidentesRepository.GetAllResidentes(PaginationDto)"/>
        public IEnumerable<Residentes> GetAllResidentes(Pagination pagination)
        {
            var sorter = Utils.Utils.OrderByFunc<Residentes>(pagination.OrderBy, string.IsNullOrEmpty(pagination.SortOrder)
                                                                               || pagination.SortOrder.Equals("desc", StringComparison.CurrentCultureIgnoreCase));

            var take = pagination.PageSize;

            var includes = new Expression<Func<Residentes, object>>[] { re => re.Copropiedades };

            var Residentes = GetPaginated(pagination.Skip, take,
                                      !string.IsNullOrEmpty(pagination.Filter) ?
                                      (re => re.IdDocumentoResidente != "" &&
                                      (re.NombresResidente + " " + re.ApellidosResidente).Contains(pagination.Filter) ||
                                      (re.IdDocumentoResidente.Contains(pagination.Filter)))
                                      : EmptyFilter,
                                      sorter, includes);

            return Residentes;
        }

        ///<see cref="IResidentesRepository.InsertResidente(Residentes)"/>
        public Residentes InsertResidente(Residentes Residente)
        {
            base.Insert(Residente);
            _context.SaveChanges();
            return Residente;
        }

        ///<see cref="IResidentesRepository.UpdateResidente(Residentes)"/>
        public Residentes UpdateResidente(Residentes Residente)
        {
            base.Update(Residente);
            _context.SaveChanges();
            return Residente;
        }

        ///<see cref="IResidentesRepository.DeleteResidente(string)"/>
        public bool DeleteResidente(string idDocumentoResidente)
        {
            base.Delete(idDocumentoResidente);
            _context.SaveChanges();
            return true;
        }

        ///<see cref="IResidentesRepository.GetResidenteById(string)"/>
        public Residentes GetResidenteById(string idDocumentoResidente)
        {
            var includes = new Expression<Func<Residentes, object>>[] { co => co.Copropiedades };
            return Get(co => co.IdDocumentoResidente.Equals(idDocumentoResidente), includes: includes).FirstOrDefault();
        }

        ///<see cref="IResidentesRepository.ExistsResidente(string)"/>
        public bool ExistsResidente(string idDocumentoResidente)
        {
            return _generalContext.Residentes.Any(co => co.IdDocumentoResidente.Equals(idDocumentoResidente));
        }
    }
}

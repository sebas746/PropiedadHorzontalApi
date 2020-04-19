using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories
{
    public class TipoCopropiedadesRepository : GenericRepository<TipoCopropiedades>, ITipoCopropiedadesRepository
    {
        public TipoCopropiedadesRepository(IBaseContext context) : base(context)
        {
        }

        public IEnumerable<TipoCopropiedades> GetAllTipoCopropiedades()
        {
            return GetAll();
        }

        public TipoCopropiedades GetTipoCopropiedadesById(int idTipoCopropiedad)
        {
            return GetByID(idTipoCopropiedad);
        }
    }
}

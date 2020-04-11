using PropiedadHorizontal.Data.Context;
using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories
{
    public class TipoDocumentosRepository : GenericRepository<TipoDocumentos>, ITipoDocumentosRepository
    {
        public TipoDocumentosRepository(IBaseContext context) : base(context)
        {
        }

        public IEnumerable<TipoDocumentos> GetAllTipoDocumentos()
        {
            return GetAll();
        }
    }
}

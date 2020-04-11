
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface ITipoDocumentosRepository
    {
        IEnumerable<TipoDocumentos> GetAllTipoDocumentos();
    }
}

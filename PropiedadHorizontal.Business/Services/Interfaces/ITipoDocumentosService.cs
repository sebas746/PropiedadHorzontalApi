

using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ITipoDocumentosService
    {
        IEnumerable<TipoDocumentosDto> GetTipoDocumentos();
    }
}

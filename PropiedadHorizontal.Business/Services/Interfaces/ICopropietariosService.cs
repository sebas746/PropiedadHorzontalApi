using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropietariosService
    {
        IEnumerable<CopropietariosDto> GetAllCopropietarios(PaginationDto pagination);
        CopropietariosDto GetCopropietarioById(string idDocumentoCopropietario);
        bool ExistsCopropietario(string idDocumentoCopropietario);
    }
}

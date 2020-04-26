using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropietariosService
    {
        IEnumerable<CopropietariosDto> GetAllCopropietarios(PaginationDto paginationDto);
        CopropietariosDto GetCopropietarioById(string idDocumentoCopropietario);
        CopropietariosDto UpdateCopropiedad(CopropietariosDto copropietarioDto);
        bool ExistsCopropietario(string idDocumentoCopropietario);
    }
}

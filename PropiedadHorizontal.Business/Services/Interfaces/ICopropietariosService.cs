using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropietariosService
    {
        IEnumerable<CopropietariosDto> GetAllCopropietarios(PaginationDto paginationDto);
        CopropietariosDto GetCopropietarioById(string idDocumentoCopropietario);
        CopropietariosDto UpdateCopropiedad(string numeroDocumento, CopropietariosDto copropietarioDto);
        bool ExistsCopropietario(string idDocumentoCopropietario);
        bool InsertCopropietarios(List<CopropietariosDto> copropietariosDto);
        CopropietariosDto InsertCopropietario(Copropietarios copropietario);
        int Count();
    }
}

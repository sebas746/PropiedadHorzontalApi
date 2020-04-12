using PropiedadHorizontal.Core.DTO;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface ICopropietariosService
    {
        CopropietariosDto GetCopropietarioById(string idDocumentoCopropietario);
        bool ExistsCopropietario(string idDocumentoCopropietario);
    }
}

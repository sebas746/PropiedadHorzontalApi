using PropiedadHorizontal.Data.Models;

namespace PropiedadHorizontal.Business.Services.Interfaces
{
    public interface IResidentesService
    {
        /// <summary>
        /// Update an existent resident. In case it does not exists,
        /// creates a new one.
        /// </summary>
        /// <param name="residente">Residente object</param>
        /// <returns></returns>
        bool UpdateResidente(Residentes residente);
    }
}

using PropiedadHorizontal.Data.Models;
using PropiedadHorizontal.Data.Utils;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface IResidentesRepository
    {
        IEnumerable<Residentes> GetAllResidentes(Pagination pagination);
        Residentes InsertResidente(Residentes Residente);
        Residentes UpdateResidente(Residentes Residente);
        bool DeleteResidente(string idDocumentoResidente);
        Residentes GetResidenteById(string idDocumentoResidente);
        bool ExistsResidente(string idDocumentoResidente);
    }
}

using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

namespace PropiedadHorizontal.Data.Repositories.Interfaces
{
    public interface IResidentesRepository
    {
        IEnumerable<Residentes> GetAllResidentes(PaginationDto pagination);
        Residentes InsertResidente(Residentes Residente);
        Residentes UpdateResidente(Residentes Residente);
        bool DeleteResidente(string idDocumentoResidente);
        Residentes GetResidenteById(string idDocumentoResidente);
        bool ExistsResidente(string idDocumentoResidente);
    }
}

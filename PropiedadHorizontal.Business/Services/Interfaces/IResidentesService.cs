using PropiedadHorizontal.Core.DTO;
using PropiedadHorizontal.Data.Models;
using System.Collections.Generic;

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

        /// <summary>
        /// Get all residentes based on a pagination object.
        /// </summary>
        /// <param name="paginationDto">Pagination object.</param>
        IEnumerable<ResidentesDto> GetAllResidentes(PaginationDto paginationDto);

        /// <summary>
        /// Deletes a residente.
        /// </summary>
        /// <param name="idDocumentoResidente"></param>
        /// <returns></returns>
        bool DeleteResidente(string idDocumentoResidente);

        /// <summary>
        /// Veriry if exists a residente.
        /// </summary>
        /// <param name="idDocumentoResidente">Id documento residente.</param>
        /// <returns></returns>
        bool ExistsResidente(string idDocumentoResidente);

        /// <summary>
        /// Creates a new residente.
        /// </summary>
        /// <param name="residenteDto">Residente DTO.</param>
        /// <returns></returns>
        Residentes CreateResidente(ResidentesDto residenteDto);

    }
}

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
    }
}

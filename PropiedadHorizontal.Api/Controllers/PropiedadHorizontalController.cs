using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using System.Linq;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadHorizontalController : ControllerBase
    {   
        private readonly IPropiedadesHorizontalesService _propiedadesHorizontalesService;

        public PropiedadHorizontalController(IPropiedadesHorizontalesService propiedadesHorizontalesService)
        {
            _propiedadesHorizontalesService = propiedadesHorizontalesService;
        }

        /// <summary>
        /// Get Vehicle List
        /// </summary>
        /// <param name="sortOrder"></param>
        /// <param name="currentSort"></param>
        /// <param name="searchString"></param>
        /// <param name="skipRows"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [Route("GetPropiedadesHorizontales/{tenantId}")]
        [HttpGet]
        public ActionResult<PaginationResponse<PropiedadHorizontalDto>> GetPropiedadesHorizontales(PaginationDto pagination)
        {
            var sortOrder = pagination.SortOrder ?? "asc";
            var currentSort = pagination.OrderBy;
            var propiedades = _propiedadesHorizontalesService.GetAllPropiedadesHorizontales(0, pagination.PageSize, pagination.Filter, 
                sortOrder, currentSort);
            var count = propiedades.Count();
            var data = new PaginationResponse<PropiedadHorizontalDto>(pagination, count)
            {   
                Content = propiedades
            };

            return Ok(data);
        }

        private static string GetValidateSortNameColumns(string currentSort)
        {
            currentSort = currentSort ?? "NombrePropiedadHorizontal";

            return currentSort;
        }
    }
}
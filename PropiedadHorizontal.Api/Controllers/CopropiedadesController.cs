using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using System.Linq;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopropiedadesController : ControllerBase
    {
        private readonly ICopropiedadesService _copropiedadesService;

        public CopropiedadesController(ICopropiedadesService copropiedadesService)
        {
            _copropiedadesService = copropiedadesService;
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
        [Route("GetCopropiedades/{tenantId}")]
        [HttpGet]
        public ActionResult<PaginationResponse<CopropiedadesDto>> GetPropiedadesHorizontales(string sortOrder,
            string currentSort, string searchString, int skipRows, int pageSize)
        {
            sortOrder = sortOrder ?? "asc";
            currentSort = GetValidateSortNameColumns(currentSort);
            var copropiedades = _copropiedadesService.GetAllCopropiedades(skipRows, pageSize, searchString,
                sortOrder, currentSort);
            var count = copropiedades.Count();
            var data = new PaginationResponse<CopropiedadesDto>
            {
                TotalCount = count,
                Content = copropiedades
            };

            return Ok(data);
        }

        private static string GetValidateSortNameColumns(string currentSort)
        {
            currentSort = currentSort ?? "Nombre";

            return currentSort;
        }
    }
}
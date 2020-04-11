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
        /// Get a list of copropiedades
        /// </summary>
        /// <param name="pagination">Pagination object.
        /// PageNumber: Page number.
        /// PageSize: Page size.
        /// OrderBy: Column name to order.
        /// SortOrder: asc or desc.
        /// Filter: Filter to search.
        /// </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PaginationResponse<CopropiedadesDto>> GetCopropiedades([FromQuery]PaginationDto pagination)
        {
            pagination.SortOrder = pagination.SortOrder ?? "asc";
            
            var copropiedades = _copropiedadesService.GetAllCopropiedades(pagination);
            var data = new PaginationResponse<CopropiedadesDto>(pagination, copropiedades.Count())
            {   
                Content = copropiedades
            };

            return Ok(data);
        }
    }
}
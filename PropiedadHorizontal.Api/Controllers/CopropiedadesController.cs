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
        [Route("GetCopropiedades")]
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
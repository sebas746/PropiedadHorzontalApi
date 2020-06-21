using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;

namespace PropiedadHorizontal.Api.Controllers
{
    /// <summary>
    /// Controller for residentes entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentesController : ControllerBase
    {
        private readonly IResidentesService _residentesService;

        /// <summary>
        /// Constructor for residentes controller.
        /// </summary>
        /// <param name="residentesService">Residentes service DI.</param>
        public ResidentesController(IResidentesService residentesService)
        {
            _residentesService = residentesService;
        }

        /// <summary>
        /// Get residentes for pagination
        /// </summary>
        /// <param name="pagination">Pagination object.</param>
        /// <returns>Residentes List.</returns>
        [HttpGet]
        [Route("GetResidentes/{nitPropiedadHorizontal}")]
        public ActionResult<PaginationResponse<ResidentesDto>> GetResidentes([FromQuery]PaginationDto pagination)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            pagination.SortOrder = pagination.SortOrder ?? "asc";
            pagination.OrderBy = pagination.OrderBy ?? "NombresResidente";

            var residentes = _residentesService.GetAllResidentes(pagination);
            var data = new PaginationResponse<ResidentesDto>(pagination, residentes.Count())
            {
                Content = residentes
            };

            return Ok(data);
        }
    }
}
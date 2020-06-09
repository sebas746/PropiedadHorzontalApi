using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResidentesController : ControllerBase
    {
        private readonly IResidentesService _residentesService;
        public ResidentesController(IResidentesService residentesService)
        {
            _residentesService = residentesService;
        }

        [HttpGet]
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
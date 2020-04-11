using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCopropiedadesController : ControllerBase
    {
        private readonly ITipoCopropiedadesService _tipoCopropiedadesService;

        public TipoCopropiedadesController(ITipoCopropiedadesService tipoCopropiedadesService)
        {
            _tipoCopropiedadesService = tipoCopropiedadesService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoCopropiedadesDto>> GetTipoDocumentos([FromQuery]PaginationDto pagination)
        {
            var tipoCopropiedades = _tipoCopropiedadesService.GetAllTipoCopropiedades();

            var data = new PaginationResponse<TipoCopropiedadesDto>(pagination, tipoCopropiedades.Count())
            {
                Content = tipoCopropiedades
            };

            return Ok(data);
        }
    }
}
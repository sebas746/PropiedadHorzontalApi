using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;
using System.Linq;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentosController : ControllerBase
    {
        private readonly ITipoDocumentosService _tipoDocumentosService;

        public TipoDocumentosController(ITipoDocumentosService tipoDocumentosService)
        {
            _tipoDocumentosService = tipoDocumentosService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TipoDocumentosDto>> GetTipoDocumentos([FromQuery]PaginationDto pagination)
        {   
            var tiposDocumentos = _tipoDocumentosService.GetTipoDocumentos();

            var data = new PaginationResponse<TipoDocumentosDto>(pagination, tiposDocumentos.Count())
            {
                Content = tiposDocumentos
            };

            return Ok(data);
        }
    }
}
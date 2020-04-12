using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopropietariosController : ControllerBase
    {
        private readonly ICopropietariosService _copropietariosService;

        public CopropietariosController(ICopropietariosService copropietariosService)
        {
            _copropietariosService = copropietariosService;
        }

        [HttpGet]
        [Route("GetCopropietarioById/{numeroDocumento}")]
        public ActionResult<CopropietariosDto> GetCopropietarioById(string numeroDocumento)
        {
            return _copropietariosService.GetCopropietarioById(numeroDocumento);
        }

        [HttpGet]
        [Route("ExistsCopropietario/{numeroDocumento}")]
        public bool ExistsCopropietario(string numeroDocumento)
        {
            return _copropietariosService.ExistsCopropietario(numeroDocumento);
        }
    }
}
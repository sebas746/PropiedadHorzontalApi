using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using System.Linq;

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

        /// <summary>
        /// Get a list of copropietarios
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
        public ActionResult<PaginationResponse<CopropietariosDto>> GetCopropietarios([FromQuery]PaginationDto pagination)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            pagination.SortOrder = pagination.SortOrder ?? "asc";
            pagination.OrderBy = pagination.OrderBy ?? "NombresCopropietario";

            var copropietarios = _copropietariosService.GetAllCopropietarios(pagination);
            var data = new PaginationResponse<CopropietariosDto>(pagination, _copropietariosService.Count())
            {
                Content = copropietarios
            };

            return Ok(data);
        }

        [HttpGet]
        [Route("GetCopropietarioById/{numeroDocumento}")]
        public ActionResult<CopropietariosDto> GetCopropietarioById(string numeroDocumento)
        {
            return _copropietariosService.GetCopropietarioById(numeroDocumento);
        }

        /// <summary>
        /// Update a copropietario.
        /// </summary>
        /// <param name="numeroDocumento">Last Número documento.</param>
        /// <param name="copropietarioDto">Copropietario DTO object.</param>
        /// <returns>Copropietario DTO updated object.</returns>
        [Route("Update/{numeroDocumento}")]
        [HttpPut]
        public ActionResult<CopropietariosDto> UpdateCopropietario(string numeroDocumento, CopropietariosDto copropietarioDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (copropietarioDto != null)
            {
                return _copropietariosService.UpdateCopropiedad(numeroDocumento, copropietarioDto);
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Route("ExistsCopropietario/{numeroDocumento}")]
        public bool ExistsCopropietario(string numeroDocumento)
        {
            return _copropietariosService.ExistsCopropietario(numeroDocumento);
        }
    }
}
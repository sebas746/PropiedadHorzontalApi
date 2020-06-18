using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;
using System.Collections.Generic;
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
            if (!ModelState.IsValid) return BadRequest(ModelState);

            pagination.SortOrder = pagination.SortOrder ?? "asc";
            pagination.OrderBy = pagination.OrderBy ?? "NombreCopropiedad";

            var copropiedades = _copropiedadesService.GetAllCopropiedades(pagination);
            var data = new PaginationResponse<CopropiedadesDto>(pagination, _copropiedadesService.Count())
            {   
                Content = copropiedades
            };

            return Ok(data);
        }

        /// <summary>
        /// Get a copropiedad by id.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns>Copropiedad DTO object.</returns>
        [HttpGet]
        [Route("GetCopropiedadById/{copropiedadId}")]
        public ActionResult<CopropiedadesDto> GetCopropiedadById(int copropiedadId)
        {
            if(copropiedadId > 0)
            {
                var copropiedad = _copropiedadesService.GetCopropiedadById(copropiedadId);

                if(copropiedad == null)
                {
                    return NotFound();
                }
                return Ok(copropiedad);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Create a new copropiedad.
        /// </summary>
        /// <param name="copropiedadDto">Copropiedad DTO object.</param>
        /// <returns>Copropiedad DTO object created.</returns>
        [Route("CreateCopropiedad")]
        [HttpPost]
        public ActionResult<CopropiedadesDto> CreateCopropiedad(CopropiedadesDto copropiedadDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if(copropiedadDto != null)
            {
                return _copropiedadesService.CreateCopropiedad(copropiedadDto);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Create a new copropiedad.
        /// </summary>
        /// <param name="copropiedadesDto">Copropiedades list DTO object.</param>
        /// <returns>Copropiedad DTO object created.</returns>
        [Route("CreateCopropiedades")]
        [HttpPost]
        public ActionResult<bool> CreateCopropiedades(List<CopropiedadesDto> copropiedadesDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (copropiedadesDto != null)
            {
                return _copropiedadesService.CreateCopropiedades(copropiedadesDto);
            }
            return BadRequest(ModelState);
        }


        /// <summary>
        /// Update a copropiedad.
        /// </summary>
        /// <param name="copropiedadDto">Copropiedad DTO object.</param>
        /// <returns>Copropiedad DTO updated object.</returns>
        [Route("Update")]
        [HttpPut]
        public ActionResult<CopropiedadesDto> UpdateCopropiedad(CopropiedadesDto copropiedadDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (copropiedadDto != null)
            {
                return _copropiedadesService.UpdateCopropiedad(copropiedadDto);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Update a residente from copropiedad.
        /// </summary>
        /// <param name="copropiedadDto">Copropiedad DTO object.</param>
        /// <returns>Copropiedad DTO updated object.</returns>
        [Route("UpdateResidenteCopropiedad")]
        [HttpPut]
        public ActionResult<CopropiedadesDto> UpdateResidenteCopropiedad(CopropiedadesDto copropiedadDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (copropiedadDto != null)
            {
                return _copropiedadesService.UpdateResidenteCopropiedad(copropiedadDto);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Deletes a copropiedad.
        /// </summary>
        /// <param name="copropiedadId">Copropiedad id.</param>
        /// <returns>
        /// True: If copropiedad was deleted.
        /// False: If copropiedad was NOT deleted.
        /// </returns>
        [Route("Delete/{tenantId}")]
        [HttpDelete]
        public ActionResult<bool> DeleteCopropiedad(int copropiedadId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (copropiedadId > 0)
            {
                return _copropiedadesService.DeleteCopropiedad(copropiedadId);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Verify is a copropiedad name is duplicated.
        /// </summary>
        /// <param name="copropiedadNombre">Copropiedad name.</param>
        /// <param name="idCopropiedad">Id copropiedad in case one is being edited.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("IsDuplicatedCopropiedad")]
        public bool IsDuplicatedNombreCopropiedad(string copropiedadNombre, int idCopropiedad)
        {
            return _copropiedadesService.ExistsCopropiedadNombre(copropiedadNombre, idCopropiedad);
        }
    }
}
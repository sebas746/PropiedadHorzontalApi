using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;

namespace PropiedadHorizontal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsComunesController : ControllerBase
    {
        private readonly IItemsComunesService _itemsComunesService;

        public ItemsComunesController(IItemsComunesService itemsComunesService)
        {
            _itemsComunesService = itemsComunesService;
        }

        /// <summary>
        /// Get a copropiedad by id.
        /// </summary>
        /// <param name="codigoAgrupador">Codigo Agrupador</param>
        /// <returns>List of Items comunes.</returns>
        [HttpGet]
        [Route("GetItemsComunesByCodigoAgrupador/{codigoAgrupador}")]
        public ActionResult<ItemsComunesDto> GetItemsComunesByCodigoAgrupador(string codigoAgrupador)
        {
            if (!string.IsNullOrEmpty(codigoAgrupador))
            {
                var items = _itemsComunesService.GetItemsComunesByCodigoAgrupador(codigoAgrupador);

                if (items == null)
                {
                    return NotFound($"El código agrupador no ha sido encontrado {codigoAgrupador}");
                }
                return Ok(items);
            }

            return BadRequest(ModelState);
        }

        /// <summary>
        /// Get a copropiedad by id.
        /// </summary>
        /// <param name="codigoAgrupador">Codigo Agrupador</param>
        /// <returns>List of Items comunes.</returns>
        [HttpGet]
        [Route("GetAllItemsComunes")]
        public ActionResult<ItemsComunesDto> GetAllItemsComunes()
        {
            var items = _itemsComunesService.GetAllItemsComunes();
            return Ok(items);
        }
    }
}
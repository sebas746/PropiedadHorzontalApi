using Microsoft.AspNetCore.Mvc;
using PropiedadHorizontal.Business.Services.Interfaces;
using PropiedadHorizontal.Core.DTO;

namespace PropiedadHorizontal.Api.Controllers
{
    /// <summary>
    /// Controller for ItemsComunes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsComunesController : ControllerBase
    {
        private readonly IItemsComunesService _itemsComunesService;

        /// <summary>
        /// Constructor for items comunes.
        /// </summary>
        /// <param name="itemsComunesService"></param>
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
        /// Get all items comunes.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllItemsComunes")]
        public ActionResult<ItemsComunesDto> GetAllItemsComunes()
        {
            var items = _itemsComunesService.GetAllItemsComunes();
            return Ok(items);
        }
    }
}
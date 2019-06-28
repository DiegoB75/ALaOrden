using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Service;


namespace TFinal.Api.Controllers
{
    [Route("api/detallefranquicia")]
    [ApiController]
    public class ProductoFranquiciaController : ControllerBase
    {
        private IProductoFranquiciaService productoFranquiciaService;
        public ProductoFranquiciaController(IProductoFranquiciaService productoFranquiciaService)
        {
            this.productoFranquiciaService = productoFranquiciaService;
        }


        [HttpGet("{IdProducto}")]
        public IEnumerable<ProductoFranquicia> GetByProducto([FromRoute] int IdProducto)
        {
            return productoFranquiciaService.ListByProducto(IdProducto);
        }

        [HttpGet("{IdFranquicia}/{IdProducto}")]
        public IActionResult GetProductoFranquicia([FromRoute] int IdFranquicia, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProductoFranquicia = productoFranquiciaService.FindById(new ProductoFranquicia { IdFranquicia = IdFranquicia, IdProducto = IdProducto });
            if (currentProductoFranquicia == null)
            {
                return NotFound();
            }
            return Ok(currentProductoFranquicia);

        }


        [HttpPost]
        public IActionResult PostProductoFranquicia([FromBody] ProductoFranquicia productoFranquicia)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productoFranquiciaService.Save(productoFranquicia);

            return CreatedAtAction("GetProductoFranquicia", new { IdFranquicia = productoFranquicia.Franquicia.IdFranquicia, IdProducto = productoFranquicia.Producto.IdProducto }, productoFranquicia);
        }


        [HttpPut("{IdFranquicia}/{IdProducto}")]
        public IActionResult PutProductoFranquicia([FromRoute] int IdFranquicia, [FromRoute] int IdProducto, [FromBody] ProductoFranquicia productoFranquicia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productoFranquicia.IdFranquicia != IdFranquicia || productoFranquicia.IdProducto != IdProducto)
            {
                return NotFound();
            }

            productoFranquiciaService.Update(productoFranquicia);

            return NoContent();
        }

        [HttpDelete("{IdFranquicia}/{IdProducto}")]
        public IActionResult DeleteProductoFranquicia([FromRoute] int IdFranquicia, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentProductoFranquicia = productoFranquiciaService.FindById(new ProductoFranquicia { IdFranquicia = IdFranquicia, IdProducto = IdProducto });

            if (currentProductoFranquicia == null)
            {
                return NotFound();
            }

            productoFranquiciaService.Delete(currentProductoFranquicia);

            return Ok(currentProductoFranquicia);
        }

    }
}
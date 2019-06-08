using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.ProductoFranquiciaService;

namespace TFinal.Api.Controllers
{
    public class ProductoFranquiciaController : ControllerBase
    {
        
        private readonly ProductoFranquiciaService productofranquiciaservice;
        public ProductoFranquiciaController(ProductoFranquiciaService context)
        {
            productofranquiciaservice = context;
        }

        [HttpGet("{IdFranquicia}")]
        public IEnumerable<ProductoFranquicia> GetProductoFranquicia([FromRoute] int IdFranquicia)
        {
            return productofranquiciaservice.ProductosFranquicias.Where(x => x.Franquicia.IdFranquicia == IdFranquicia).ToList();
        }

        [HttpGet("{IdFranquicia}/{IdProducto}")]
        public async Task<ActionResult> GetProductoFranquicia([FromRoute] int IdFranquicia,[FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProductoFranquicia = await productofranquiciaservice.ProductosFranquicias.FirstOrDefaultAsync(x => x.Franquicia.IdFranquicia == IdFranquicia && x.Producto.IdProducto == IdProducto);

            if (currentProductoFranquicia == null)
            {
                return NotFound();
            }
            return Ok(currentProductoFranquicia);
        }

        [HttpPost]
        public async Task<ActionResult> PostProductoFranquicia([FromBody] ProductoFranquicia productoFranquicia){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            productofranquiciaservice.ProductosFranquicias.Add(productoFranquicia);
            await productofranquiciaservice.SaveChangesAsync();

            return CreatedAtAction("GetCarrito", new { IdFranquicia = productoFranquicia.Franquicia.IdFranquicia, idProducto = productoFranquicia.Producto.IdProducto}, productoFranquicia);
        }

        [HttpDelete("{IdFranquicia}/{IdProducto}")]
        public async Task<ActionResult> DeleteProductoFranquicia([FromBody] int IdFranquicia,[FromBody] int IdProducto){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var currentProductoFranquicia = await productofranquiciaservice.ProductosFranquicias.FirstOrDefaultAsync(x => x.Franquicia.IdFranquicia == IdFranquicia && x.Producto.IdProducto == IdProducto);
            if (currentProductoFranquicia == null)
            {
                return NotFound();
            }

            productofranquiciaservice.ProductosFranquicias.Remove(currentProductoFranquicia);
            await productofranquiciaservice.SaveChangesAsync();

            return Ok(currentProductoFranquicia);
        }
    }
}
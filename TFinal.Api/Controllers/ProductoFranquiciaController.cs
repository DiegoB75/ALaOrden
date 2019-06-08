using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Service;

namespace TFinal.Api.Controllers
{
    public class ProductoFranquiciaController : ControllerBase
    {
        
        private readonly IProductoFranquiciaService productoFranquiciaService;
        public ProductoFranquiciaController(IProductoFranquiciaService productoFranquiciaService)
        {
            this.productoFranquiciaService = productoFranquiciaService;
        }

        [HttpGet("{IdFranquicia}")]
        public IEnumerable<ProductoFranquicia> GetProductoFranquicia([FromRoute] int IdFranquicia)
        {
            var productoFranquicia = new ProductoFranquicia();
            productoFranquicia.IdFranquicia = IdFranquicia;
            productoFranquiciaService.FindById(productoFranquicia);

            List<ProductoFranquicia> productoFranquicias = new List<ProductoFranquicia>();
            productoFranquicias.Add(productoFranquicia);
            
            return productoFranquicias;
        }

        [HttpGet("{IdFranquicia}/{IdProducto}")]
        public async Task<ActionResult> GetProductoFranquicia([FromRoute] int IdFranquicia,[FromRoute] int IdProducto)
        {
            var productoFranquicia = new ProductoFranquicia();
            productoFranquicia.IdFranquicia = IdFranquicia;
            productoFranquicia.IdProducto = IdProducto;
            var productoFranquiciaGet = productoFranquiciaService.FindById(productoFranquicia);

            return Ok(productoFranquiciaGet);
        }

        [HttpPost]
        public async Task<ActionResult> PostProductoFranquicia([FromBody] ProductoFranquicia productoFranquicia){
            productoFranquiciaService.Save(productoFranquicia);

            return CreatedAtAction("GetCarrito", new { IdFranquicia = productoFranquicia.Franquicia.IdFranquicia, idProducto = productoFranquicia.Producto.IdProducto}, productoFranquicia);
        }

        [HttpDelete("{IdFranquicia}/{IdProducto}")]
        public async Task<ActionResult> DeleteProductoFranquicia([FromBody] int IdFranquicia,[FromBody] int IdProducto){
            var productoFranquicia = new ProductoFranquicia();
            productoFranquicia.IdFranquicia = IdFranquicia;
            productoFranquicia.IdProducto = IdProducto;
            productoFranquiciaService.Delete(productoFranquicia);
            return Ok();
        }
    }
}
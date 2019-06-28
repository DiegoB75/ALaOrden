using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Service;

namespace TFinal.Api.Controllers
{
    [Route("api/producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoService productoService;
        public ProductoController(IProductoService productoService)
        {
            this.productoService = productoService;
        }
        [HttpGet]
        public IEnumerable<Producto> GetProducto()
        {
            return productoService.ListAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetProducto([FromRoute] int id)
        {
            Producto producto = new Producto();
            producto.IdProducto = id;

            var productoGet = productoService.FindById(producto);

            return Ok(productoGet);

        }

        [HttpPost]
        public IActionResult PostProducto([FromBody] Producto producto)
        {

            productoService.Save(producto);

            return CreatedAtAction("GetProducto", new { id = producto.IdProducto }, producto);
        }


        [HttpPut("{id}")]
        public IActionResult PutProducto([FromRoute] int id, [FromBody] Producto producto)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if (producto.IdProducto != id){
                return BadRequest();
            }

            productoService.Update(producto);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProducto([FromRoute] int id)
        {
            var producto = new Producto();
            producto.IdProducto = id;
            productoService.Delete(producto);
            return Ok();
        }

    }
}
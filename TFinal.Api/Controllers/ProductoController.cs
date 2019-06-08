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
    [Produces("application/json")]
    [Route("api/Producto")]
    public class ProductoController:ControllerBase
    {
         private readonly IProductoService productoService;
        public ProductoController (IProductoService productoService){
            this.productoService=productoService;
        }
       [HttpGet]
        public IEnumerable<Producto> GetProducto() {
            return productoService.ListAll();
        }

        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return null;
        }

        [HttpGet]
        public IEnumerable<Marca> GetMarca() {
            return null;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] int id)
        {
            Producto producto = new Producto();
            producto.IdProducto = id;

            var productoGet = productoService.FindById(producto);

            return Ok(productoGet);

        }     

        [HttpPost]
         public async Task<IActionResult> PostProducto([FromBody] Producto producto){

           productoService.Save(producto);

            return CreatedAtAction ("GetProducto", new {id = producto.IdProducto},producto);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutProducto ([FromRoute] int id){
             
             var producto = new Producto();
             producto.IdProducto = id;
             productoService.Update(producto);

             return Ok();
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteProducto ([FromRoute] int id){
             var producto = new Producto();
             producto.IdProducto = id;
             productoService.Delete(producto);
             return Ok();
         }

    }
}
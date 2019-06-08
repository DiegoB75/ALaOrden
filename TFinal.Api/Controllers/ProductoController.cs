using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.ProductoService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Producto")]
    public class ProductoController:ControllerBase
    {
         private readonly ProductoService productoservice;
        public ProductoController (ProductoService context){
            productoservice=context;
        }
       [HttpGet]
        public IEnumerable<Producto> GetProducto() {
            return productoservice.Productos;
        }

        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return productoservice.Categorias;
        }

        [HttpGet]
        public IEnumerable<Marca> GetMarca() {
            return productoservice.Marcas;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProducto = await productoservice.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

            if(currentProducto == null)
            {
                return NotFound();
            }

            return Ok(currentProducto);

        }     

        [HttpPost]
         public async Task<IActionResult> PostProducto([FromBody] Producto producto){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productoservice.Productos.Add(producto);
            await productoservice.SaveChangesAsync();

            return CreatedAtAction ("GetProducto", new {id = producto.IdProducto},producto);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutProducto ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentProducto = await productoservice.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

             if(currentProducto == null){
                 return NotFound();
             }

             productoservice.Productos.Update(currentProducto);
             await productoservice.SaveChangesAsync();

             return Ok(currentProducto);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteProducto ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentProducto = await productoservice.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

             if(currentProducto == null){
                 return NotFound();
             }

             productoservice.Productos.Remove(currentProducto);
             await productoservice.SaveChangesAsync();

             return Ok(currentProducto);
         }

    }
}
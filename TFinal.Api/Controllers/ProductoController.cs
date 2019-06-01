using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Producto")]
    public class ProductoController:ControllerBase
    {
         private readonly ApplicationDbContext _context;
        public ProductoController (ApplicationDbContext context){
            _context=context;
        }
       [HttpGet]
        public IEnumerable<Producto> GetProducto() {
            return _context.Productos;
        }

        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return _context.Categorias;
        }

        [HttpGet]
        public IEnumerable<Marca> GetMarca() {
            return _context.Marcas;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetProducto([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentProducto = await _context.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

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

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetProducto", new {id = producto.IdProducto},producto);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutProducto ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentProducto = await _context.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

             if(currentProducto == null){
                 return NotFound();
             }

             _context.Productos.Update(currentProducto);
             await _context.SaveChangesAsync();

             return Ok(currentProducto);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteProducto ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentProducto = await _context.Productos.SingleOrDefaultAsync(p => p.IdProducto == id);

             if(currentProducto == null){
                 return NotFound();
             }

             _context.Productos.Remove(currentProducto);
             await _context.SaveChangesAsync();

             return Ok(currentProducto);
         }

    }
}
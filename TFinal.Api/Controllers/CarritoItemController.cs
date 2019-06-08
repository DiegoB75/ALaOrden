using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/carrito")]
    public class CarritoItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CarritoItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{idUsuario}")]
        public IEnumerable<CarritoItem> GetCarrito([FromRoute] int idUsuario)
        {
            return _context.Carritos.Where(x => x.Usuario.IdUsuario == idUsuario).ToList();
        }

        [HttpGet("{idUsuario}/{idProducto}")]
        public async Task<ActionResult> GetCarrito([FromRoute] int idUsuario,[FromRoute] int idProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCarrito = await _context.Carritos.FirstOrDefaultAsync(x => x.Usuario.IdUsuario == idUsuario && x.Producto.IdProducto == idProducto);

            if (currentCarrito == null)
            {
                return NotFound();
            }
            return Ok(currentCarrito);
        }

        [HttpPost]
        public async Task<ActionResult> PostCarrito([FromBody] CarritoItem carrito){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrito", new { idUsuario = carrito.Usuario.IdUsuario, idProducto = carrito.Producto.IdProducto}, carrito);
        }

        [HttpDelete("{idUsuario}/{idProducto}")]
        public async Task<ActionResult> DeleteCarrito([FromBody] int idUsuario,[FromBody] int idProducto){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var currentCarrito = await _context.Carritos.FirstOrDefaultAsync(x => x.Usuario.IdUsuario == idUsuario && x.Producto.IdProducto == idProducto);
            if (currentCarrito == null)
            {
                return NotFound();
            }

            _context.Carritos.Remove(currentCarrito);
            await _context.SaveChangesAsync();

            return Ok(currentCarrito);
        }
    }
}
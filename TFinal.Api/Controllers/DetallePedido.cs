using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/DetallePedido")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DetallePedidoController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<DetallePedido> GetDetallesPedido()
        {
            return _context.DetallesPedido;
        }

        /*[HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return _context.Pedidos;
        }

         [HttpGet]
        public IEnumerable<Producto> GetProducto() {
            return _context.Productos;
        }*/

        [HttpGet("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> GetDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentDetallePedido = await _context.DetallesPedido.SingleOrDefaultAsync(p => p.Pedido.IdPedido == IdPedido && p.Producto.IdProducto == IdProducto);

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            return Ok(currentDetallePedido);

        }


        [HttpPost]
        public async Task<IActionResult> PostDetallePedido([FromBody] DetallePedido DetallePedido)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DetallesPedido.Add(DetallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePedido", new { IdPedido = DetallePedido.Pedido.IdPedido, IdProducto = DetallePedido.Producto.IdProducto }, DetallePedido);
        }


        [HttpPut("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> PutDetallePedido([FromBody] int IdPedido, [FromBody] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = await _context.DetallesPedido.SingleOrDefaultAsync(p => p.Pedido.IdPedido == IdPedido && p.Producto.IdProducto == IdProducto);

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedido.Update(currentDetallePedido);
            await _context.SaveChangesAsync();

            return Ok(currentDetallePedido);
        }

        [HttpDelete("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> DeleteDetallePedido([FromBody] int IdPedido, [FromBody] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = await _context.DetallesPedido.SingleOrDefaultAsync(p => p.Pedido.IdPedido == IdPedido && p.Producto.IdProducto == IdProducto);

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedido.Remove(currentDetallePedido);
            await _context.SaveChangesAsync();

            return Ok(currentDetallePedido);
        }

    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Services.DetallePedidoService;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/DetallePedido")]
    public class DetallePedidoController : ControllerBase
    {
        private readonly DetallePedidoService detallepedidoservice;
        public DetallePedidoController(DetallePedidoService context)
        {
            detallepedidoservice = context;
        }


        [HttpGet]
        public IEnumerable<DetallePedido> GetDetallesPedido()
        {
            return detallepedidoservice.DetallesPedido;
        }

        /*[HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return detallepedidoservice.Pedidos;
        }

         [HttpGet]
        public IEnumerable<Producto> GetProducto() {
            return detallepedidoservice.Productos;
        }*/

        [HttpGet("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> GetDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentDetallePedido = await detallepedidoservice.DetallesPedido.SingleOrDefaultAsync(p => p.Pedido.IdPedido == IdPedido && p.Producto.IdProducto == IdProducto);

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

            detallepedidoservice.DetallesPedido.Add(DetallePedido);
            await detallepedidoservice.SaveChangesAsync();

            return CreatedAtAction("GetDetallePedido", new { IdPedido = DetallePedido.Pedido.IdPedido, IdProducto = DetallePedido.Producto.IdProducto }, DetallePedido);
        }


        [HttpPut("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> PutDetallePedido([FromBody] int IdPedido, [FromBody] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = await detallepedidoservice.DetallesPedido.SingleOrDefaultAsync(p => p.Pedido.IdPedido == IdPedido && p.Producto.IdProducto == IdProducto);

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            detallepedidoservice.DetallesPedido.Update(currentDetallePedido);
            await detallepedidoservice.SaveChangesAsync();

            return Ok(currentDetallePedido);
        }

        [HttpDelete("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> DeleteDetallePedido([FromBody] int IdPedido, [FromBody] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = await detallepedidoservice.DetallesPedido.SingleOrDefaultAsync(p => p.Pedido.IdPedido == IdPedido && p.Producto.IdProducto == IdProducto);

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            detallepedidoservice.DetallesPedido.Remove(currentDetallePedido);
            await detallepedidoservice.SaveChangesAsync();

            return Ok(currentDetallePedido);
        }

    }
}
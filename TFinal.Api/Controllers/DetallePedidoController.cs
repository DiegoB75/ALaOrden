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
    //[Produces("application/json")]
    [Route("api/DetallePedido")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoService detallePedidoService;
        public DetallePedidoController(IDetallePedidoService detallePedidoService)
        {
            this.detallePedidoService = detallePedidoService;
        }


        [HttpGet]
        public IEnumerable<DetallePedido> GetDetallesPedido()
        {
            return detallePedidoService.ListAll();
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
            var currentDetallePedido = detallePedidoService.FindById(new DetallePedido{IdPedido = IdPedido, IdProducto = IdProducto});
            if (currentDetallePedido == null)
            {
                return NotFound();
            }
            return Ok(currentDetallePedido);

        }


        [HttpPost]
        public async Task<IActionResult> PostDetallePedido([FromBody] DetallePedido detallePedido)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            detallePedidoService.Save(detallePedido);

            return CreatedAtAction("GetDetallePedido", new { IdPedido = detallePedido.Pedido.IdPedido, IdProducto = detallePedido.Producto.IdProducto }, detallePedido);
        }


        [HttpPut("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> PutDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto, [FromBody] DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = detallePedidoService.FindById(new DetallePedido{IdPedido = IdPedido, IdProducto = IdProducto});
            
            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            detallePedidoService.Update(currentDetallePedido);

            return Ok(currentDetallePedido);
        }

        [HttpDelete("{IdPedido}/{IdProducto}")]
        public async Task<IActionResult> DeleteDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = detallePedidoService.FindById(new DetallePedido{IdPedido = IdPedido, IdProducto = IdProducto});

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            detallePedidoService.Delete(currentDetallePedido);

            return Ok(currentDetallePedido);
        }

    }
}
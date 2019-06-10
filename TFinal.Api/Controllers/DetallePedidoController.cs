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
    [Route("api/detallepedido")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private IDetallePedidoService detallePedidoService;
        public DetallePedidoController(IDetallePedidoService detallePedidoService)
        {
            this.detallePedidoService = detallePedidoService;
        }


        [HttpGet]
        public IEnumerable<DetallePedido> GetDetallesPedido()
        {
            return detallePedidoService.ListAll();
        }

        [HttpGet("{IdPedido}/{IdProducto}")]
        public IActionResult GetDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentDetallePedido = detallePedidoService.FindById(new DetallePedido { IdPedido = IdPedido, IdProducto = IdProducto });
            if (currentDetallePedido == null)
            {
                return NotFound();
            }
            return Ok(currentDetallePedido);

        }


        [HttpPost]
        public IActionResult PostDetallePedido([FromBody] DetallePedido detallePedido)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            detallePedidoService.Save(detallePedido);

            return CreatedAtAction("GetDetallePedido", new { IdPedido = detallePedido.Pedido.IdPedido, IdProducto = detallePedido.Producto.IdProducto }, detallePedido);
        }


        [HttpPut("{IdPedido}/{IdProducto}")]
        public IActionResult PutDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto, [FromBody] DetallePedido detallePedido)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (detallePedido.IdPedido != IdPedido || detallePedido.IdProducto != IdProducto)
            {
                return NotFound();
            }

            detallePedidoService.Update(detallePedido);

            return NoContent();
        }

        [HttpDelete("{IdPedido}/{IdProducto}")]
        public IActionResult DeleteDetallePedido([FromRoute] int IdPedido, [FromRoute] int IdProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDetallePedido = detallePedidoService.FindById(new DetallePedido { IdPedido = IdPedido, IdProducto = IdProducto });

            if (currentDetallePedido == null)
            {
                return NotFound();
            }

            detallePedidoService.Delete(currentDetallePedido);

            return Ok(currentDetallePedido);
        }

    }
}
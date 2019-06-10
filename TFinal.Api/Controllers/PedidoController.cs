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
    [Route("api/pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoService pedidoService;
        public PedidoController (IPedidoService pedidoService){
            this.pedidoService= pedidoService;
        }


        [HttpGet("user={idUsuario}")]
        public IEnumerable<Pedido> GetByUsuario([FromRoute] int idUsuario) {
            return pedidoService.ListByUsuario(idUsuario);
        }


       [HttpGet("{id}")]
        public IActionResult GetPedido([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentPedido = pedidoService.FindById(new Pedido{ IdPedido = id });

            if(currentPedido == null)
            {
                return NotFound();
            }

            return Ok(currentPedido);

        }     

        [HttpPost]
         public IActionResult PostPedido([FromBody] Pedido pedido){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pedidoService.Save(pedido);

            return CreatedAtAction ("GetSede", new {id = pedido.IdPedido},pedido);
         }

         
         [HttpPut("{id}")]
         public IActionResult PutPedido ([FromRoute] int id, [FromBody] Pedido pedido){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             if(pedido.IdPedido != id){
                 return BadRequest();
             }

             pedidoService.Update(pedido);
             return Ok(pedido);
         }
        [HttpDelete("{id}")]
          public IActionResult DeletePedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentPedido = pedidoService.FindById(new Pedido{ IdPedido = id });

             if(currentPedido == null){
                 return NotFound();
             }

             pedidoService.Delete(currentPedido);

             return Ok(currentPedido);
         }
    }
}
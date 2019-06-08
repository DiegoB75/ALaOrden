using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.PedidoService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoService pedidoservice;
        public PedidoController (PedidoService context){
            pedidoservice=context;
        }


        [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return pedidoservice.Pedidos;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetPedido([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentPedido = await pedidoservice.Pedidos.SingleOrDefaultAsync(p => p.IdPedido == id);

            if(currentPedido == null)
            {
                return NotFound();
            }

            return Ok(currentPedido);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostPedido([FromBody] Pedido pedido){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            pedidoservice.Pedidos.Add(pedido);
            await pedidoservice.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = pedido.IdPedido},pedido);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutPedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentPedido = await pedidoservice.Pedidos.SingleOrDefaultAsync(p => p.IdPedido == id);

             if(currentPedido == null){
                 return NotFound();
             }

             pedidoservice.Pedidos.Update(currentPedido);
             await pedidoservice.SaveChangesAsync();

             return Ok(currentPedido);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeletePedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentPedido = await pedidoservice.Pedidos.SingleOrDefaultAsync(p => p.IdPedido == id);

             if(currentPedido == null){
                 return NotFound();
             }

             pedidoservice.Pedidos.Remove(currentPedido);
             await pedidoservice.SaveChangesAsync();

             return Ok(currentPedido);
         }
    }
}
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
    [Route("api/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PedidoController (ApplicationDbContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return _context.Pedidos;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetPedido([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentPedido = await _context.Pedidos.SingleOrDefaultAsync(p => p.IdPedido == id);

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

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = pedido.IdPedido},pedido);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutPedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentPedido = await _context.Pedidos.SingleOrDefaultAsync(p => p.IdPedido == id);

             if(currentPedido == null){
                 return NotFound();
             }

             _context.Pedidos.Update(currentPedido);
             await _context.SaveChangesAsync();

             return Ok(currentPedido);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeletePedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentPedido = await _context.Pedidos.SingleOrDefaultAsync(p => p.IdPedido == id);

             if(currentPedido == null){
                 return NotFound();
             }

             _context.Pedidos.Remove(currentPedido);
             await _context.SaveChangesAsync();

             return Ok(currentPedido);
         }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlaOrden.TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/DetallePedido")]
    public class DetallePedidoController:ControllerBase
    {
         private readonly ProyectoDBContext _context;
        public DetallePedidoController (ProyectoDBContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<DetallePedido> GetDetallePedido() {
            return _context.DetallePedidos;
        }

         [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return _context.Pedido;
        }

         [HttpGet]
        public IEnumerable<Producto> GetProducto() {
            return _context.Producto;
        }

       [HttpGet ("{id}")]
        public async Task<IActionResult> GetDetallePedido([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentDetallePedido = await _context.DetallePedidos.SingleOrDefaultAsync(p => p.IdDetallePedido == id);

            if(currentDetallePedido == null)
            {
                return NotFound();
            }

            return Ok(currentDetallePedido);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostDetallePedido([FromBody] DetallePedido DetallePedido){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DetallePedidos.Add(DetallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetDetallePedido", new {id = DetallePedido.IdDetallePedido},DetallePedido);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutDetallePedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDetallePedido = await _context.DetallePedidos.SingleOrDefaultAsync(p => p.IdDetallePedido == id);

             if(currentDetallePedido == null){
                 return NotFound();
             }

             _context.DetallePedidos.Update(currentDetallePedido);
             await _context.SaveChangesAsync();

             return Ok(currentDetallePedido);
         }

          public async Task<IActionResult> DeleteDetallePedido ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDetallePedido = await _context.DetallePedidos.SingleOrDefaultAsync(p => p.IdDetallePedido == id);

             if(currentDetallePedido == null){
                 return NotFound();
             }

             _context.DetallePedidos.Remove(currentDetallePedido);
             await _context.SaveChangesAsync();

             return Ok(currentDetallePedido);
         }

    }
}
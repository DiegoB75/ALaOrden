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
    [Route("api/Cupon")]
    public class CuponController:ControllerBase
    {
         private readonly ApplicationDbContext _context;
        public CuponController (ApplicationDbContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Cupon> GetCupon() {
            return _context.Cupones;
        }

         [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return _context.Pedidos;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCupon([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCupon = await _context.Cupones.SingleOrDefaultAsync(p => p.IdCupon == id);

            if(currentCupon == null)
            {
                return NotFound();
            }

            return Ok(currentCupon);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostCupon([FromBody] Cupon cupon){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cupones.Add(cupon);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetCupon", new {id = cupon.IdCupon},cupon);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCupon ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCupon = await _context.Cupones.SingleOrDefaultAsync(p => p.IdCupon == id);

             if(currentCupon == null){
                 return NotFound();
             }

             _context.Cupones.Update(currentCupon);
             await _context.SaveChangesAsync();

             return Ok(currentCupon);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCupon ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCupon = await _context.Cupones.SingleOrDefaultAsync(p => p.IdCupon == id);

             if(currentCupon == null){
                 return NotFound();
             }

             _context.Cupones.Remove(currentCupon);
             await _context.SaveChangesAsync();

             return Ok(currentCupon);
         }

    }
}
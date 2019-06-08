using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.ServiceCupon;
using TFinal.Services.CuponService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Cupon")]
    public class CuponController:ControllerBase
    {
         private readonly CuponService cuponservice;
        public CuponController (CuponService context){
            cuponservice=context;
        }


        [HttpGet]
        public IEnumerable<Cupon> GetCupon() {
            return cuponservice.Cupones;
        }

         [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return cuponservice.Pedidos;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCupon([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCupon = await cuponservice.Cupones.SingleOrDefaultAsync(p => p.IdCupon == id);

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

            cuponservice.Cupones.Add(cupon);
            await cuponservice.SaveChangesAsync();

            return CreatedAtAction ("GetCupon", new {id = cupon.IdCupon},cupon);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCupon ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCupon = await cuponservice.Cupones.SingleOrDefaultAsync(p => p.IdCupon == id);

             if(currentCupon == null){
                 return NotFound();
             }

             cuponservice.Cupones.Update(currentCupon);
             await cuponservice.SaveChangesAsync();

             return Ok(currentCupon);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCupon ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCupon = await cuponservice.Cupones.SingleOrDefaultAsync(p => p.IdCupon == id);

             if(currentCupon == null){
                 return NotFound();
             }

             cuponservice.Cupones.Remove(currentCupon);
             await cuponservice.SaveChangesAsync();

             return Ok(currentCupon);
         }

    }
}
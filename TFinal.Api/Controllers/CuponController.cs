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
    //[Produces("application/json")]
    [Route("api/Cupon")]
    [ApiController]
    public class CuponController:ControllerBase
    {
        private readonly ICuponService cuponService;
        public CuponController (ICuponService cuponService){
            this.cuponService=cuponService;
        }


        [HttpGet]
        public IEnumerable<Cupon> GetCupon() {
            return cuponService.ListAll();
        }

        /* 
        [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return cuponService.Pedidos;
        }
        */


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCupon([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCupon = cuponService.FindById(new Cupon{IdCupon = id});

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

            cuponService.Save(cupon);

            return CreatedAtAction ("GetCupon", new {id = cupon.IdCupon},cupon);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCupon ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCupon = cuponService.FindById(new Cupon{IdCupon = id});

             if(currentCupon == null){
                 return NotFound();
             }

             cuponService.Update(currentCupon);

             return Ok(currentCupon);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCupon ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCupon = cuponService.FindById(new Cupon{IdCupon = id});

             if(currentCupon == null){
                 return NotFound();
             }

             cuponService.Delete(currentCupon);

             return Ok(currentCupon);
         }

    }
}
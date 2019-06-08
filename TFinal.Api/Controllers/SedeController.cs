using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.SedeService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Sede")]
    public class SedeController:ControllerBase
    {
         private readonly SedeService sedeservice;
        public SedeController (SedeService context){
            sedeservice=context;
        }


        [HttpGet]
        public IEnumerable<Sede> GetSede() {
            return sedeservice.Sedes;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetSede([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentSede = await sedeservice.Sedes.SingleOrDefaultAsync(p => p.IdSede == id);

            if(currentSede == null)
            {
                return NotFound();
            }

            return Ok(currentSede);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostSede([FromBody] Sede sede){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sedeservice.Sedes.Add(sede);
            await sedeservice.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = sede.IdSede},sede);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutSede ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentSede = await sedeservice.Sedes.SingleOrDefaultAsync(p => p.IdSede == id);

             if(currentSede == null){
                 return NotFound();
             }

             sedeservice.Sedes.Update(currentSede);
             await sedeservice.SaveChangesAsync();

             return Ok(currentSede);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteSede ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentSede = await sedeservice.Sedes.SingleOrDefaultAsync(p => p.IdSede == id);

             if(currentSede == null){
                 return NotFound();
             }

             sedeservice.Sedes.Remove(currentSede);
             await sedeservice.SaveChangesAsync();

             return Ok(currentSede);
         }

    }
}
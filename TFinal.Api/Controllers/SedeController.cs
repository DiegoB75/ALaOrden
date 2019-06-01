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
    [Route("api/Sede")]
    public class SedeController:ControllerBase
    {
         private readonly ApplicationDbContext _context;
        public SedeController (ApplicationDbContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Sede> GetSede() {
            return _context.Sedes;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetSede([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentSede = await _context.Sedes.SingleOrDefaultAsync(p => p.IdSede == id);

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

            _context.Sedes.Add(sede);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = sede.IdSede},sede);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutSede ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentSede = await _context.Sedes.SingleOrDefaultAsync(p => p.IdSede == id);

             if(currentSede == null){
                 return NotFound();
             }

             _context.Sedes.Update(currentSede);
             await _context.SaveChangesAsync();

             return Ok(currentSede);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteSede ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentSede = await _context.Sedes.SingleOrDefaultAsync(p => p.IdSede == id);

             if(currentSede == null){
                 return NotFound();
             }

             _context.Sedes.Remove(currentSede);
             await _context.SaveChangesAsync();

             return Ok(currentSede);
         }

    }
}
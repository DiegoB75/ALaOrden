using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/franquicia")]
    public class FranquiciaController:ControllerBase
    {
         private readonly ApplicationDbContext _context;
        public FranquiciaController (ApplicationDbContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Franquicia> GetFranquicia() {
            return _context.Franquicias;
        }

       [HttpGet ("{id}")]
        public async Task<IActionResult> GetFranquicia([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentFranquicia = await _context.Franquicias.SingleOrDefaultAsync(p => p.IdFranquicia == id);

            if(currentFranquicia == null)
            {
                return NotFound();
            }

            return Ok(currentFranquicia);

        }


        [HttpPost]
         public async Task<IActionResult> PostFranquicia([FromBody] Franquicia Franquicia){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Franquicias.Add(Franquicia);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetFranquicia", new {id = Franquicia.IdFranquicia },Franquicia);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutFranquicia ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentFranquicia = await _context.Franquicias.SingleOrDefaultAsync(p => p.IdFranquicia == id);

             if(currentFranquicia == null){
                 return NotFound();
             }

             _context.Franquicias.Update(currentFranquicia);
             await _context.SaveChangesAsync();

             return Ok(currentFranquicia);
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteFranquicia ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentFranquicia = await _context.Franquicias.SingleOrDefaultAsync(p => p.IdFranquicia == id);

             if(currentFranquicia == null){
                 return NotFound();
             }

             _context.Franquicias.Remove(currentFranquicia);
             await _context.SaveChangesAsync();

             return Ok(currentFranquicia);
         }
    }
}
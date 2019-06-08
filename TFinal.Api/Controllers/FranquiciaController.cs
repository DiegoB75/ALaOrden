using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Services.FranquiciaService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/franquicia")]
    public class FranquiciaController:ControllerBase
    {
         private readonly FranquiciaService franquiciaservice;
        public FranquiciaController (FranquiciaService context){
            franquiciaservice=context;
        }


        [HttpGet]
        public IEnumerable<Franquicia> GetFranquicia() {
            return franquiciaservice.Franquicias;
        }

       [HttpGet ("{id}")]
        public async Task<IActionResult> GetFranquicia([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentFranquicia = await franquiciaservice.Franquicias.SingleOrDefaultAsync(p => p.IdFranquicia == id);

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

            franquiciaservice.Franquicias.Add(Franquicia);
            await franquiciaservice.SaveChangesAsync();

            return CreatedAtAction ("GetFranquicia", new {id = Franquicia.IdFranquicia },Franquicia);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutFranquicia ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentFranquicia = await franquiciaservice.Franquicias.SingleOrDefaultAsync(p => p.IdFranquicia == id);

             if(currentFranquicia == null){
                 return NotFound();
             }

             franquiciaservice.Franquicias.Update(currentFranquicia);
             await franquiciaservice.SaveChangesAsync();

             return Ok(currentFranquicia);
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteFranquicia ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentFranquicia = await franquiciaservice.Franquicias.SingleOrDefaultAsync(p => p.IdFranquicia == id);

             if(currentFranquicia == null){
                 return NotFound();
             }

             franquiciaservice.Franquicias.Remove(currentFranquicia);
             await franquiciaservice.SaveChangesAsync();

             return Ok(currentFranquicia);
         }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Service;

namespace TFinal.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/franquicia")]
    [ApiController]
    public class FranquiciaController:ControllerBase
    {
         private readonly IFranquiciaService franquiciaService;
        public FranquiciaController (IFranquiciaService franquiciaService){
            this.franquiciaService= franquiciaService;
        }


        [HttpGet]
        public IEnumerable<Franquicia> GetFranquicia() {
            return franquiciaService.ListAll();
        }

       [HttpGet ("{id}")]
        public async Task<IActionResult> GetFranquicia([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentFranquicia = franquiciaService.FindById(new Franquicia{ IdFranquicia = id});

            if(currentFranquicia == null)
            {
                return NotFound();
            }

            return Ok(currentFranquicia);

        }


        [HttpPost]
         public async Task<IActionResult> PostFranquicia([FromBody] Franquicia franquicia){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            franquiciaService.Save(franquicia);

            return CreatedAtAction ("GetFranquicia", new {id = franquicia.IdFranquicia },franquicia);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutFranquicia ([FromRoute] int id, [FromBody] Franquicia franquicia){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentFranquicia = franquiciaService.FindById(new Franquicia{IdFranquicia = id});

             if(currentFranquicia == null){
                 return NotFound();
             }

             franquiciaService.Update(currentFranquicia);

             return Ok(currentFranquicia);
         }

         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteFranquicia ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentFranquicia = franquiciaService.FindById(new Franquicia{IdFranquicia = id});

             if(currentFranquicia == null){
                 return NotFound();
             }

             franquiciaService.Delete(currentFranquicia);

             return Ok(currentFranquicia);
         }
    }
}
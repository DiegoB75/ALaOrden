using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.MarcaService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Marca")]
    public class MarcaController:ControllerBase
    {
         private readonly MarcaService marcaservice;
        public MarcaController (MarcaService context){
            marcaservice=context;
        }
       [HttpGet]
        public IEnumerable<Marca> GetMarca() {
            return marcaservice.Marcas;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetMarca([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentMarca = await marcaservice.Marcas.SingleOrDefaultAsync(p => p.IdMarca == id);

            if(currentMarca == null)
            {
                return NotFound();
            }

            return Ok(currentMarca);

        }     

        [HttpPost]
         public async Task<IActionResult> PostMarca([FromBody] Marca marca){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            marcaservice.Marcas.Add(marca);
            await marcaservice.SaveChangesAsync();

            return CreatedAtAction ("GetMarca", new {id = marca.IdMarca},marca);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutMarca ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentMarca = await marcaservice.Marcas.SingleOrDefaultAsync(p => p.IdMarca == id);

             if(currentMarca == null){
                 return NotFound();
             }

             marcaservice.Marcas.Update(currentMarca);
             await marcaservice.SaveChangesAsync();

             return Ok(currentMarca);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteMarca ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentMarca = await marcaservice.Marcas.SingleOrDefaultAsync(p => p.IdMarca == id);

             if(currentMarca == null){
                 return NotFound();
             }

             marcaservice.Marcas.Remove(currentMarca);
             await marcaservice.SaveChangesAsync();

             return Ok(currentMarca);
         }

    }
}
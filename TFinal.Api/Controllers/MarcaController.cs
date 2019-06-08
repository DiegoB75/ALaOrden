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
    [Produces("application/json")]
    [Route("api/Marca")]
    [ApiController]
    public class MarcaController:ControllerBase
    {
         private readonly IMarcaService marcaService;
        public MarcaController (IMarcaService marcaService){
            this.marcaService= marcaService;
        }
       [HttpGet]
        public IEnumerable<Marca> GetMarca() {
            return marcaService.ListAll();
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetMarca([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentMarca = marcaService.FindById(new Marca{ IdMarca = id});

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

            marcaService.Save(marca);

            return CreatedAtAction ("GetMarca", new {id = marca.IdMarca},marca);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutMarca ([FromRoute] int id, [FromBody] Marca marca){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentMarca = marcaService.FindById(new Marca{IdMarca = id});

             if(currentMarca == null){
                 return NotFound();
             }

             marcaService.Update(currentMarca);

             return Ok(currentMarca);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteMarca ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentMarca = marcaService.FindById(new Marca{IdMarca = id});

             if(currentMarca == null){
                 return NotFound();
             }

             marcaService.Delete(currentMarca);

             return Ok(currentMarca);
         }

    }
}
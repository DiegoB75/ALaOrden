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
    [Route("api/Sede")]
    public class SedeController:ControllerBase
    {
         private readonly ISedeService sedeService;
        public SedeController (ISedeService sedeService){
            this.sedeService=sedeService;
        }


        [HttpGet]
        public IEnumerable<Sede> GetSede() {
            return sedeService.ListAll();
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetSede([FromRoute] int id)
        {
            Sede sede = new Sede();
            sede.IdSede = id;

            var sedeGet = sedeService.FindById(sede);
            return Ok(sedeGet);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostSede([FromBody] Sede sede){

            sedeService.Save(sede);

            return CreatedAtAction ("GetSede", new {id = sede.IdSede},sede);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutSede ([FromRoute] int id){
             
             Sede sede =new Sede();
             sede.IdSede = id;
             sedeService.Update(sede);

             return Ok();
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteSede ([FromRoute] int id){
             Sede sede = new Sede();
             sede.IdSede = id;
             sedeService.Delete(sede);
             return Ok();
         }

    }
}
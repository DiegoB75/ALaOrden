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
    [Route("api/Direccion")]
    [ApiController]
    public class DireccionController:ControllerBase
    {
         private readonly IDireccionService direccionService;
        public DireccionController (IDireccionService direccionService){
            this.direccionService= direccionService;
        }


        [HttpGet]
        public IEnumerable<Direccion> GetDireccion() {
            return direccionService.ListAll();
        }

        /*
        [HttpGet]
        public IEnumerable<Usuario> GetUsuario() {
            return direccionService.Usuarios;
        } */


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetDireccion([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currenDireccion = direccionService.FindById(new Direccion{ IdDireccion = id});

            if(currenDireccion == null)
            {
                return NotFound();
            }

            return Ok(currenDireccion);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostDireccion([FromBody] Direccion direccion){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            direccionService.Save(direccion);

            return CreatedAtAction ("GetDireccion", new {id = direccion.IdDireccion},direccion);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutDireccion ([FromRoute] int id, [FromBody] Direccion direccion){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = direccionService.FindById(new Direccion{ IdDireccion = id});

             if(currentDireccion == null){
                 return NotFound();
             }

             direccionService.Update(currentDireccion);

             return Ok(currentDireccion);
         }
            [HttpDelete("{id}")]

          public async Task<IActionResult> DeleteDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = direccionService.FindById(new Direccion{ IdDireccion = id});

             if(currentDireccion == null){
                 return NotFound();
             }

             direccionService.Delete(currentDireccion);

             return Ok(currentDireccion);
         }

    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.DireccionService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Direccion")]
    public class DireccionController:ControllerBase
    {
         private readonly DireccionService direccionservice;
        public DireccionController (DireccionService context){
            direccionservice=context;
        }


        [HttpGet]
        public IEnumerable<Direccion> GetDireccion() {
            return direccionservice.Direcciones;
        }

         [HttpGet]
        public IEnumerable<Usuario> GetUsuario() {
            return direccionservice.Usuarios;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetDireccion([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currenDireccion = await direccionservice.Direcciones.SingleOrDefaultAsync(p => p.IdDireccion == id);

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

            direccionservice.Direcciones.Add(direccion);
            await direccionservice.SaveChangesAsync();

            return CreatedAtAction ("GetDireccion", new {id = direccion.IdDireccion},direccion);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = await direccionservice.Direcciones.SingleOrDefaultAsync(p => p.IdDireccion == id);

             if(currentDireccion == null){
                 return NotFound();
             }

             direccionservice.Direcciones.Update(currentDireccion);
             await direccionservice.SaveChangesAsync();

             return Ok(currentDireccion);
         }
            [HttpDelete("{id}")]

          public async Task<IActionResult> DeleteDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = await direccionservice.Direcciones.SingleOrDefaultAsync(p => p.IdDireccion == id);

             if(currentDireccion == null){
                 return NotFound();
             }

             direccionservice.Direcciones.Remove(currentDireccion);
             await direccionservice.SaveChangesAsync();

             return Ok(currentDireccion);
         }

    }
}
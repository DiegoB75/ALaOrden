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
    [Route("api/Direccion")]
    public class DireccionController:ControllerBase
    {
         private readonly ApplicationDbContext _context;
        public DireccionController (ApplicationDbContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Direccion> GetDireccion() {
            return _context.Direcciones;
        }

         [HttpGet]
        public IEnumerable<Usuario> GetUsuario() {
            return _context.Usuarios;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetDireccion([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currenDireccion = await _context.Direcciones.SingleOrDefaultAsync(p => p.IdDireccion == id);

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

            _context.Direcciones.Add(direccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetDireccion", new {id = direccion.IdDireccion},direccion);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = await _context.Direcciones.SingleOrDefaultAsync(p => p.IdDireccion == id);

             if(currentDireccion == null){
                 return NotFound();
             }

             _context.Direcciones.Update(currentDireccion);
             await _context.SaveChangesAsync();

             return Ok(currentDireccion);
         }

          public async Task<IActionResult> DeleteDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = await _context.Direcciones.SingleOrDefaultAsync(p => p.IdDireccion == id);

             if(currentDireccion == null){
                 return NotFound();
             }

             _context.Direcciones.Remove(currentDireccion);
             await _context.SaveChangesAsync();

             return Ok(currentDireccion);
         }

    }
}
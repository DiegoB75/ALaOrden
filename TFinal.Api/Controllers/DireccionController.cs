using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlaOrden.TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Direccion")]
    public class DireccionController:ControllerBase
    {
         private readonly ProyectoDBContext _context;
        public DireccionController (ProyectoDBContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Direccion> GetDireccion() {
            return _context.Direccion;
        }

         [HttpGet]
        public IEnumerable<Usuario> GetUsuario() {
            return _context.Usuario;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetDireccion([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currenDireccion = await _context.Direccion.SingleOrDefaultAsync(p => p.IdDireccion == id);

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

            _context.Direccion.Add(direccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetDireccion", new {id = direccion.IdDireccion},direccion);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = await _context.Direccion.SingleOrDefaultAsync(p => p.IdDireccion == id);

             if(currentDireccion == null){
                 return NotFound();
             }

             _context.Direccion.Update(currentDireccion);
             await _context.SaveChangesAsync();

             return Ok(currentDireccion);
         }

          public async Task<IActionResult> DeleteDireccion ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentDireccion = await _context.Direccion.SingleOrDefaultAsync(p => p.IdDireccion == id);

             if(currentDireccion == null){
                 return NotFound();
             }

             _context.Direccion.Remove(currentDireccion);
             await _context.SaveChangesAsync();

             return Ok(currentDireccion);
         }

    }
}
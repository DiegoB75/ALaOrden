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
    [Route("api/Marca")]
    public class MarcaController:ControllerBase
    {
         private readonly ApplicationDbContext _context;
        public MarcaController (ApplicationDbContext context){
            _context=context;
        }
       [HttpGet]
        public IEnumerable<Marca> GetMarca() {
            return _context.Marcas;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetMarca([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentMarca = await _context.Marcas.SingleOrDefaultAsync(p => p.IdMarca == id);

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

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetMarca", new {id = marca.IdMarca},marca);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutMarca ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentMarca = await _context.Marcas.SingleOrDefaultAsync(p => p.IdMarca == id);

             if(currentMarca == null){
                 return NotFound();
             }

             _context.Marcas.Update(currentMarca);
             await _context.SaveChangesAsync();

             return Ok(currentMarca);
         }
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteMarca ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentMarca = await _context.Marcas.SingleOrDefaultAsync(p => p.IdMarca == id);

             if(currentMarca == null){
                 return NotFound();
             }

             _context.Marcas.Remove(currentMarca);
             await _context.SaveChangesAsync();

             return Ok(currentMarca);
         }

    }
}
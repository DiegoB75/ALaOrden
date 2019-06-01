using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoriaController (ApplicationDbContext context){
            _context=context;
        }


        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return _context.Categorias;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCategoria = await _context.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

            if(currentCategoria == null)
            {
                return NotFound();
            }

            return Ok(currentCategoria);

        }     
      



        [HttpPost]
         public async Task<IActionResult> PostCategoria([FromBody] Categoria categoria){

             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = categoria.IdCategoria},categoria);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await _context.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             //pasar contenido de Body a currentCategoria

             _context.Categorias.Update(currentCategoria);
             await _context.SaveChangesAsync();

             return Ok(currentCategoria);
         }

         /*
                  [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id, [FromBody] Categoria categoria){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await _context.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             _context.Categorias.Update(currentCategoria);
             await _context.SaveChangesAsync();

             return Ok(currentCategoria);
         }
         
          */
         
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCategoria ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await _context.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             _context.Categorias.Remove(currentCategoria);
             await _context.SaveChangesAsync();

             return Ok(currentCategoria);
         }
    }
}
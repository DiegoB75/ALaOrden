using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Services.CategoriaService;

namespace TFinal.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private CategoriaService categoriaservice;
        public CategoriaController (CategoriaService context){
            categoriaservice=context;
        }


        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return categoriaservice.Categorias;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCategoria = await categoriaservice.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

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

            categoriaservice.Categorias.Add(categoria);
            await categoriaservice.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = categoria.IdCategoria},categoria);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await categoriaservice.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             //pasar contenido de Body a currentCategoria

             categoriaservice.Categorias.Update(currentCategoria);
             await categoriaservice.SaveChangesAsync();

             return Ok(currentCategoria);
         }

         /*
                  [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id, [FromBody] Categoria categoria){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await categoriaservice.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             categoriaservice.Categorias.Update(currentCategoria);
             await categoriaservice.SaveChangesAsync();

             return Ok(currentCategoria);
         }
         
          */
         
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCategoria ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await categoriaservice.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             categoriaservice.Categorias.Remove(currentCategoria);
             await categoriaservice.SaveChangesAsync();

             return Ok(currentCategoria);
         }
    }
}
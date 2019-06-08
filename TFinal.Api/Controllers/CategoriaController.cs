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
        private readonly ServiceCategoria servicecategoria;
        public CategoriaController (ServiceCategoriaItem context){
            servicecategoria=context;
        }


        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return servicecategoria.Categorias;
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCategoria = await servicecategoria.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

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

            servicecategoria.Categorias.Add(categoria);
            await servicecategoria.SaveChangesAsync();

            return CreatedAtAction ("GetSede", new {id = categoria.IdCategoria},categoria);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await servicecategoria.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             //pasar contenido de Body a currentCategoria

             servicecategoria.Categorias.Update(currentCategoria);
             await servicecategoria.SaveChangesAsync();

             return Ok(currentCategoria);
         }

         /*
                  [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id, [FromBody] Categoria categoria){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await servicecategoria.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             servicecategoria.Categorias.Update(currentCategoria);
             await servicecategoria.SaveChangesAsync();

             return Ok(currentCategoria);
         }
         
          */
         
        [HttpDelete("{id}")]
          public async Task<IActionResult> DeleteCategoria ([FromRoute] int id){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = await servicecategoria.Categorias.SingleOrDefaultAsync(p => p.IdCategoria == id);

             if(currentCategoria == null){
                 return NotFound();
             }

             servicecategoria.Categorias.Remove(currentCategoria);
             await servicecategoria.SaveChangesAsync();

             return Ok(currentCategoria);
         }
    }
}
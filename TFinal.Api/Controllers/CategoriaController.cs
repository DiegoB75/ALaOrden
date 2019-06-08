using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Service;

namespace TFinal.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaService categoriaservice;
        public CategoriaController (ICategoriaService context){
            categoriaservice=context;
        }


        [HttpGet]
        public IEnumerable<Categoria> GetCategoria() {
            return categoriaservice.ListAll();
        }


       [HttpGet ("{id}")]
        public async Task<IActionResult> GetCategoria([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCategoria = categoriaservice.FindById(new Categoria{ IdCategoria = id});

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

            categoriaservice.Save(categoria);

            return CreatedAtAction ("GetSede", new {id = categoria.IdCategoria},categoria);
         }

         
         [HttpPut("{id}")]
         public async Task<IActionResult> PutCategoria ([FromRoute] int id, [FromBody] Categoria categoria){
             if(!ModelState.IsValid){
                 return BadRequest(ModelState);
             }

             var currentCategoria = categoriaservice.FindById(new Categoria{ IdCategoria = id});

             if(currentCategoria == null){
                 return NotFound();
             }

             categoriaservice.Update(currentCategoria);

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

             var currentCategoria = categoriaservice.FindById(new Categoria{ IdCategoria = id});

             if(currentCategoria == null){
                 return NotFound();
             }

             categoriaservice.Delete(currentCategoria);

             return Ok(currentCategoria);
         }
    }
}
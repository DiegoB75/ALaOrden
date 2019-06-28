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
    [Route("api/categoria")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaService categoriaService;
        public CategoriaController(ICategoriaService context)
        {
            categoriaService = context;
        }


        [HttpGet]
        public IEnumerable<Categoria> GetCategoria()
        {
            return categoriaService.ListAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCategoria = categoriaService.FindById(new Categoria { IdCategoria = id });

            if (currentCategoria == null)
            {
                return NotFound();
            }

            return Ok(currentCategoria);

        }


        [HttpPost]
        public IActionResult PostCategoria([FromBody] Categoria categoria)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            categoriaService.Save(categoria);

            return CreatedAtAction("GetSede", new { id = categoria.IdCategoria }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult PutCategoria([FromRoute] int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            categoriaService.Update(categoria);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategoria([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentCategoria = categoriaService.FindById(new Categoria { IdCategoria = id });

            if (currentCategoria == null)
            {
                return NotFound();
            }

            categoriaService.Delete(currentCategoria);

            return Ok(currentCategoria);
        }
    }
}
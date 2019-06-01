using System.Collections.Generic;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private IMarcaRepository marcaRepository;
        public MarcaController(IMarcaRepository marcaRepository)
        {
            this.marcaRepository=marcaRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Marca>>Get(){
            return marcaRepository.ListAll();
        }

        [HttpGet("{id}", Name="GetMarca")]
        public ActionResult<Marca> Get(Marca marca){
            var autor = marcaRepository.FindById(marca);
            if(autor == null)
            {
                 return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Marca marca) {
            marcaRepository.Save(marca);
            return new CreatedAtRouteResult("GetMarca",new {id=marca.IdMarca}, marca);
           
        }


    }
}
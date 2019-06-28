using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFinal.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFinal.Repository.Context;
using TFinal.Service;

namespace TFinal.Api.Controllers
{
    [Route("api/sede")]
    [ApiController]
    public class SedeController : ControllerBase
    {
        private ISedeService sedeService;
        public SedeController(ISedeService sedeService)
        {
            this.sedeService = sedeService;
        }


        [HttpGet]
        public IEnumerable<Sede> GetSede()
        {
            return sedeService.ListAll();
        }


        [HttpGet("{id}")]
        public IActionResult GetSede([FromRoute] int id)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            
            var currentSede = sedeService.FindById(new Sede{ IdSede = id});

            if (currentSede == null){
                return BadRequest();
            }
            return Ok(currentSede);
        }

        [HttpPost]
        public IActionResult PostSede([FromBody] Sede sede)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            sedeService.Save(sede);

            return CreatedAtAction("GetSede", new { id = sede.IdSede }, sede);
        }

        [HttpPut("{id}")]
        public IActionResult PutSede([FromRoute] int id, [FromBody] Sede sede)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            if (sede.IdSede != id){
                return BadRequest();
            }
            sedeService.Update(sede);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSede([FromRoute] int id)
        {
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var currentSede = sedeService.FindById(new Sede{ IdSede = id});
            if (currentSede == null){
                return BadRequest();
            }
            sedeService.Delete(currentSede);

            return Ok(currentSede);
        }

    }
}
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
            Sede sede = new Sede();
            sede.IdSede = id;

            var sedeGet = sedeService.FindById(sede);
            return Ok(sedeGet);

        }

        [HttpPost]
        public IActionResult PostSede([FromBody] Sede sede)
        {

            sedeService.Save(sede);

            return CreatedAtAction("GetSede", new { id = sede.IdSede }, sede);
        }

        [HttpPut("{id}")]
        public IActionResult PutSede([FromRoute] int id)
        {
            Sede sede = new Sede();
            sede.IdSede = id;
            sedeService.Update(sede);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSede([FromRoute] int id)
        {
            Sede sede = new Sede();
            sede.IdSede = id;
            sedeService.Delete(sede);
            return Ok();
        }

    }
}
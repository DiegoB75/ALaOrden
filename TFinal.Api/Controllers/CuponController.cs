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
    [Route("api/cupon")]
    [ApiController]
    public class CuponController : ControllerBase
    {
        private ICuponService cuponService;
        public CuponController(ICuponService cuponService)
        {
            this.cuponService = cuponService;
        }


        [HttpGet]
        public IEnumerable<Cupon> GetCupon()
        {
            return cuponService.ListAll();
        }

        /* 
        [HttpGet]
        public IEnumerable<Pedido> GetPedido() {
            return cuponService.Pedidos;
        }
        */


        [HttpGet("{id}")]
        public IActionResult GetCupon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCupon = cuponService.FindById(new Cupon { IdCupon = id });

            if (currentCupon == null)
            {
                return NotFound();
            }

            return Ok(currentCupon);

        }

        [HttpPost]
        public IActionResult PostCupon([FromBody] Cupon cupon)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            cuponService.Save(cupon);

            return CreatedAtAction("GetCupon", new { id = cupon.IdCupon }, cupon);
        }


        [HttpPut("{id}")]
        public IActionResult PutCupon([FromRoute] int id, [FromBody] Cupon cupon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (cupon.IdCupon != id)
            {
                return BadRequest();
            }

            cuponService.Update(cupon);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCupon([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentCupon = cuponService.FindById(new Cupon { IdCupon = id });

            if (currentCupon == null)
            {
                return NotFound();
            }

            cuponService.Delete(currentCupon);

            return Ok(currentCupon);
        }

    }
}
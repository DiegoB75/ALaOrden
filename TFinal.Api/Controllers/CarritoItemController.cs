using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Domain;
using Microsoft.EntityFrameworkCore;
using TFinal.Service;

namespace TFinal.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/carrito")]
    [ApiController]
    public class CarritoItemController : ControllerBase
    {
        private  ICarritoItemService carritoItemService;
        public CarritoItemController(ICarritoItemService carritoItemService)
        {
           this.carritoItemService= carritoItemService;
        }

        [HttpGet("{idUsuario}")]
        public IEnumerable<CarritoItem> GetCarrito([FromRoute] int idUsuario)
        {
            //TODO: implmentar filtro en service
            return carritoItemService.ListAll();
        }

        [HttpGet("{idUsuario}/{idProducto}")]
        public async Task<ActionResult> GetCarrito([FromRoute] int idUsuario,[FromRoute] int idProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var currentCarrito = carritoItemService.FindById(new CarritoItem{ IdUsuario = idUsuario, IdProducto = idProducto});


            if (currentCarrito == null)
            {
                return NotFound();
            }
            return Ok(currentCarrito);
        }

        [HttpPost]
        public async Task<ActionResult> PostCarrito([FromBody] CarritoItem carrito){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            carritoItemService.Save(carrito);

            return CreatedAtAction("GetCarrito", new { idUsuario = carrito.IdUsuario, idProducto = carrito.IdProducto}, carrito);
        }

        [HttpDelete("{idUsuario}/{idProducto}")]
        public async Task<ActionResult> DeleteCarrito([FromRoute] int idUsuario,[FromRoute] int idProducto){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var currentCarrito = carritoItemService.FindById(new CarritoItem{ IdUsuario = idUsuario, IdProducto = idProducto});

            if (currentCarrito == null)
            {
                return NotFound();
            }

            carritoItemService.Delete(currentCarrito);


            return Ok(currentCarrito);
        }
    }
}
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
    [Route("api/carrito")]
    [ApiController]
    public class CarritoItemController : ControllerBase
    {
        //methods: GetByUsuario, 

        private  ICarritoItemService carritoItemService;
        public CarritoItemController(ICarritoItemService carritoItemService)
        {
           this.carritoItemService= carritoItemService;
        }

        [HttpGet("{idUsuario}")]
        public IEnumerable<CarritoItem> GetCarrito([FromRoute] int idUsuario)
        {
            //TODO: implmentar filtro en service
            return carritoItemService.ListByUsuario(idUsuario);
        }

        //Necesario ??
        [HttpGet("{idUsuario}/{idProducto}")]
        public IActionResult GetCarritoItem([FromRoute] int idUsuario,[FromRoute] int idProducto)
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
        public IActionResult PostCarrito([FromBody] CarritoItem carrito){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            carritoItemService.Save(carrito);

            return CreatedAtAction("GetCarrito", new { idUsuario = carrito.IdUsuario, idProducto = carrito.IdProducto}, carrito);
        }

        [HttpPut("{idUsuario}/{idProducto}")]
        public IActionResult PutCarrito([FromRoute] int idUsuario, [FromRoute] int idProducto, [FromBody] CarritoItem carrito){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            if (idUsuario != carrito.IdUsuario || idProducto != carrito.IdProducto){
                return BadRequest();
            }

            carritoItemService.Update(carrito);
            return NoContent();
        }

        [HttpDelete("{idUsuario}/{idProducto}")]
        public IActionResult DeleteCarritoItem([FromRoute] int idUsuario,[FromRoute] int idProducto){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            var currentCarrito = carritoItemService.FindById(new CarritoItem{ IdUsuario = idUsuario, IdProducto = idProducto});
            if (currentCarrito == null)
            {
                return NotFound();
            }

            carritoItemService.Delete(currentCarrito);
            return NoContent();
        }

        [HttpDelete("{idUsuario}")]
        public IActionResult DeleteCarrito([FromRoute] int idUsuario){
            if (!ModelState.IsValid){
                return BadRequest(ModelState);
            }

            carritoItemService.emptyCart(idUsuario);
            return NoContent();
        }
    }
}
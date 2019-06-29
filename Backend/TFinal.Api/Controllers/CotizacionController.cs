using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFinal.Service;
using TFinal.Domain;
namespace TFinal.Api.Controllers
{
    [Route("api/cotizacion")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private IPedidoService pedidoService;
        private IDireccionService direccionService;
        private ICarritoItemService carritoItemService;
        private ISedeService sedeService;
        public CotizacionController(ICarritoItemService carritoItemService,IDireccionService direccionService,IPedidoService pedidoService,ISedeService sedeService)
        {
            this.carritoItemService = carritoItemService;
            this.direccionService = direccionService;
            this.pedidoService = pedidoService;
            this.sedeService = sedeService;
        }
        // GET api/values
        [HttpPut("{idUsuario}")]
        public IActionResult Cotizar([FromRoute] int idUsuario,[FromBody] Direccion direccion)
        {
            List<CarritoItem> carrito = carritoItemService.ListByUsuario(idUsuario);

            if (carrito == null)
            {
                return NotFound();
            }
           List<Sede> sedes = sedeService.ListAll();
           List <Pedido> pedidos = pedidoService.GenerateList(carrito,sedes);
            if(pedidos!=null){
            pedidos = direccionService.LlenarDeliveryPrice(pedidos,direccion);
            }

            return Ok(pedidos);
        }


    }
}

using System.Collections.Generic;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.AspNetCore.Mvc;

namespace TFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoRepository productoRepository;
        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository=productoRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>>Get(){
            return productoRepository.ListAll();
        }

        [HttpGet("{id}", Name="GetProducto")]
        public ActionResult<Producto> Get(Producto producto){
            var autor = productoRepository.FindById(producto);
            if(autor == null)
            {
                 return NotFound();
            }
            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Producto producto) {
            productoRepository.Save(producto);
            return new CreatedAtRouteResult("GetProducto",new {id=producto.IdProducto}, producto);
           
        }


    }
}
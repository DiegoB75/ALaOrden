using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class ProductoService : IProductoService
    {
        private IProductoRepository productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public void Delete(Producto entity)
        {
            productoRepository.Delete(entity);
        }

        public Producto FindById(Producto entity)
        {
            return productoRepository.FindById(entity);
        }

        public List<Producto> ListAll()
        {
            return productoRepository.ListAll();
        }

        public void Save(Producto entity)
        {
            productoRepository.Save(entity);
        }

        public void Update(Producto entity)
        {
            productoRepository.Update(entity);
        }
    }
}
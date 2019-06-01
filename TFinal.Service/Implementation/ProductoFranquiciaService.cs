using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class ProductoFranquiciaService : IProductoFranquiciaService
    {
        private IProductoFranquiciaRepository productoFranquiciaRepository;

        public ProductoFranquiciaService(IProductoFranquiciaRepository productoFranquiciaRepository)
        {
            this.productoFranquiciaRepository = productoFranquiciaRepository;
        }

        public void Delete(ProductoFranquicia entity)
        {
            productoFranquiciaRepository.Delete(entity);
        }

        public ProductoFranquicia FindById(ProductoFranquicia entity)
        {
            return productoFranquiciaRepository.FindById(entity);
        }

        public List<ProductoFranquicia> ListAll()
        {
            return productoFranquiciaRepository.ListAll();
        }

        public void Save(ProductoFranquicia entity)
        {
            productoFranquiciaRepository.Save(entity);
        }

        public void Update(ProductoFranquicia entity)
        {
            productoFranquiciaRepository.Update(entity);
        }
    }
}
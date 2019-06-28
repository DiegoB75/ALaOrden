using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class ProductoFranquiciaRepository : IProductoFranquiciaRepository
    {
        private ApplicationDbContext context;
        public ProductoFranquiciaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(ProductoFranquicia entity)
        {
            context.ProductosFranquicias.Remove(entity);
            context.SaveChanges();
        }

        public ProductoFranquicia FindById(ProductoFranquicia entity)
        {
            return context.ProductosFranquicias.FirstOrDefault(x => 
                x.IdProducto == entity.IdProducto &&
                x.IdFranquicia == entity.IdFranquicia);
        }

        public List<ProductoFranquicia> ListAll()
        {
            throw new System.NotImplementedException();
        }

        public List<ProductoFranquicia> ListByProducto(int idProducto)
        {
            return context.ProductosFranquicias.Where(x => x.IdProducto == idProducto).ToList();
        }
        public void Save(ProductoFranquicia entity)
        {
            context.ProductosFranquicias.Add(entity);
            context.SaveChanges();
        }

        public void Update(ProductoFranquicia entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
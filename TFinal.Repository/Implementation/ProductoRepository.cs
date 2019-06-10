using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class ProductoRepository : IProductoRepository
    {
        private ApplicationDbContext context;
        public ProductoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Producto entity)
        {
            context.Productos.Remove(entity);
            context.SaveChanges();
        }

        public Producto FindById(Producto entity)
        {
            return context.Productos.Include(x => x.Categoria).Include(x => x.Marca).Include(x=> x.ProductoFranquicias).FirstOrDefault(x => x.IdProducto == entity.IdProducto);
        }

        public List<Producto> ListAll()
        {
            return context.Productos.Include(x => x.Categoria).Include(x => x.Marca).ToList();
        }

        public void Save(Producto entity)
        {
            context.Productos.Add(entity);
            context.SaveChanges();
        }

        public void Update(Producto entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
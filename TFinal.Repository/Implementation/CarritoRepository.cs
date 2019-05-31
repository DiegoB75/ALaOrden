using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class CarritoRepository : ICarritoRepository
    {
        private ApplicationDbContext context;

        public CarritoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Carrito entity)
        {
            context.Carritos.Remove(entity);
            context.SaveChanges();
        }

        public Carrito FindById(Carrito entity)
        {
            return context.Carritos.FirstOrDefault(x =>
                x.Producto.IdProducto == entity.Producto.IdProducto &&
                x.Usuario.IdUsuario == entity.Usuario.IdUsuario);
        }

        public List<Carrito> ListAll()
        {
            return context.Carritos.ToList();
        }

        public void Save(Carrito entity)
        {
            context.Carritos.Add(entity);
            context.SaveChanges();
        }

        public void Update(Carrito entity)
        {
             context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
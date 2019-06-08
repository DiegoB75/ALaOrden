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
        public void Delete(CarritoItem entity)
        {
            context.Carritos.Remove(entity);
            context.SaveChanges();
        }

        public CarritoItem FindById(CarritoItem entity)
        {
            return context.Carritos.FirstOrDefault(x =>
                x.Producto.IdProducto == entity.Producto.IdProducto &&
                x.Usuario.IdUsuario == entity.Usuario.IdUsuario);
        }

        public List<CarritoItem> ListAll()
        {
            return context.Carritos.ToList();
        }

        public void Save(CarritoItem entity)
        {
            context.Carritos.Add(entity);
            context.SaveChanges();
        }

        public void Update(CarritoItem entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
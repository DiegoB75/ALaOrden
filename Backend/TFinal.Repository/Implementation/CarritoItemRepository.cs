using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class CarritoItemRepository : ICarritoItemRepository
    {
        private ApplicationDbContext context;

        public CarritoItemRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Delete(CarritoItem entity)
        {
            context.CarritoItems.Remove(entity);
            context.SaveChanges();
        }

        public CarritoItem FindById(CarritoItem entity)
        {
            return context.CarritoItems.Include(x => x.Producto).FirstOrDefault(x =>
                  x.IdProducto == entity.IdProducto &&
                  x.IdUsuario == entity.IdUsuario);
        }

        public List<CarritoItem> ListAll()
        {
            throw new System.NotImplementedException();
        }

        public List<CarritoItem> ListByUsuario(int idUsuario)
        {
            return context.CarritoItems.Include(x => x.Producto).Where(x => x.IdUsuario == idUsuario).ToList();
        }

        public void Save(CarritoItem entity)
        {
            context.CarritoItems.Add(entity);
            context.SaveChanges();
        }

        public void Update(CarritoItem entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
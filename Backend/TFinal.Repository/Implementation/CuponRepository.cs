using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class CuponRepository : ICuponRepository
    {
        private ApplicationDbContext context;
        public CuponRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Cupon entity)
        {
            context.Cupones.Remove(entity);
            context.SaveChanges();
        }

        public Cupon FindById(Cupon entity)
        {
            return context.Cupones.FirstOrDefault(x => x.IdCupon == entity.IdCupon);
        }

        public List<Cupon> ListAll()
        {
            return context.Cupones.ToList();
        }

        public void Save(Cupon entity)
        {
            context.Cupones.Add(entity);
            context.SaveChanges();
        }

        public void Update(Cupon entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
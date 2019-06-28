using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class SedeRepository : ISedeRepository
    {
        private ApplicationDbContext context;
        public SedeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Sede entity)
        {
            context.Sedes.Remove(entity);
            context.SaveChanges();
        }

        public Sede FindById(Sede entity)
        {
            return context.Sedes.Include(x => x.Franquicia).FirstOrDefault(x => x.IdSede == entity.IdSede);
        }

        public List<Sede> ListAll()
        {
            return context.Sedes.Include(x => x.Franquicia).ToList();
        }

        public void Save(Sede entity)
        {
            context.Sedes.Add(entity);
            context.SaveChanges();
        }

        public void Update(Sede entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
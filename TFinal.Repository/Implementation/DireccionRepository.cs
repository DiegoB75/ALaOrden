using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class DireccionRepository : IDireccionRepository
    {
        private ApplicationDbContext context;
        public DireccionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Direccion entity)
        {
            context.Direcciones.Remove(entity);
            context.SaveChanges();
        }

        public Direccion FindById(Direccion entity)
        {
            return context.Direcciones.FirstOrDefault(x => x.IdDireccion == entity.IdDireccion);
        }

        public List<Direccion> ListAll()
        {
            return context.Direcciones.ToList();
        }

        public void Save(Direccion entity)
        {
            context.Direcciones.Add(entity);
            context.SaveChanges();
        }

        public void Update(Direccion entity)
        {
             context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
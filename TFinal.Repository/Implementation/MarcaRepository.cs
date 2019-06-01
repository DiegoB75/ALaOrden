using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class MarcaRepository : IMarcaRepository
    {
        private ApplicationDbContext context;
        public MarcaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Marca entity)
        {
            context.Marcas.Remove(entity);
            context.SaveChanges();
        }

        public Marca FindById(Marca entity)
        {
            return context.Marcas.FirstOrDefault(x => x.IdMarca == entity.IdMarca);
        }

        public List<Marca> ListAll()
        {
            return context.Marcas.ToList();
        }

        public void Save(Marca entity)
        {
            context.Marcas.Add(entity);
            context.SaveChanges();
        }

        public void Update(Marca entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
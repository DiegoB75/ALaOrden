using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class FranquiciaRepository : IFranquiciaRepository
    {
        ApplicationDbContext context;
        public FranquiciaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Franquicia entity)
        {
            context.Franquicias.Remove(entity);
            context.SaveChanges();
        }

        public Franquicia FindById(Franquicia entity)
        {
            return context.Franquicias.FirstOrDefault(x => x.IdFranquicia == entity.IdFranquicia);
        }

        public List<Franquicia> ListAll()
        {
            return context.Franquicias.ToList();
        }

        public void Save(Franquicia entity)
        {
            context.Franquicias.Add(entity);
            context.SaveChanges();
        }

        public void Update(Franquicia entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext context;
        public CategoriaRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Categoria entity)
        {
            context.Categorias.Remove(entity);
            context.SaveChanges();
        }

        public Categoria FindById(Categoria entity)
        {
            return context.Categorias.FirstOrDefault(x=> x.IdCategoria == entity.IdCategoria);
        }

        public List<Categoria> ListAll()
        {
            return context.Categorias.ToList();
        }

        public void Save(Categoria entity)
        {
            context.Categorias.Add(entity);
            context.SaveChanges();
        }

        public void Update(Categoria entity)
        {
             context.Entry(entity).State=EntityState.Modified;
  
            context.SaveChanges();
        }
    }
}
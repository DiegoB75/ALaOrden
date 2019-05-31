using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;

namespace TFinal.Repository.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private ApplicationDbContext context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Usuario entity)
        {
            context.Usuarios.Remove(entity);
            context.SaveChanges();
        }

        public Usuario FindById(Usuario entity)
        {
            return context.Usuarios.FirstOrDefault(x => x.IdUsuario == entity.IdUsuario);
        }

        public List<Usuario> ListAll()
        {
            return context.Usuarios.ToList();
        }

        public void Save(Usuario entity)
        {
            context.Usuarios.Add(entity);
            context.SaveChanges();
        }

        public void Update(Usuario entity)
        {
            context.Usuarios.Update(entity);
            context .SaveChanges();
        }
    }
}
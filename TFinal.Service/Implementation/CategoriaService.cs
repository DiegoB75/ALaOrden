using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository = categoriaRepository;
        }

        public void Delete(Categoria entity)
        {
            categoriaRepository.Delete(entity);
        }

        public Categoria FindById(Categoria entity)
        {
            return categoriaRepository.FindById(entity);
        }

        public List<Categoria> ListAll()
        {
            return categoriaRepository.ListAll();
        }

        public void Save(Categoria entity)
        {
            categoriaRepository.Save(entity);
        }

        public void Update(Categoria entity)
        {
            categoriaRepository.Update(entity);
        }
    }
}
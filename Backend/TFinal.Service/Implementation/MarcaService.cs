using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class MarcaService : IMarcaService
    {
        private IMarcaRepository marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            this.marcaRepository = marcaRepository;
        }

        public void Delete(Marca entity)
        {
            marcaRepository.Delete(entity);
        }

        public Marca FindById(Marca entity)
        {
            return marcaRepository.FindById(entity);
        }

        public List<Marca> ListAll()
        {
            return marcaRepository.ListAll();
        }

        public void Save(Marca entity)
        {
            marcaRepository.Save(entity);
        }

        public void Update(Marca entity)
        {
            marcaRepository.Update(entity);
        }
    }
}
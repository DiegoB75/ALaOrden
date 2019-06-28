using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class SedeService : ISedeService
    {
        private ISedeRepository sedeRepository;

        public SedeService(ISedeRepository sedeRepository)
        {
            this.sedeRepository = sedeRepository;
        }

        public void Delete(Sede entity)
        {
            sedeRepository.Delete(entity);
        }

        public Sede FindById(Sede entity)
        {
            return sedeRepository.FindById(entity);
        }

        public List<Sede> ListAll()
        {
            return sedeRepository.ListAll();
        }

        public void Save(Sede entity)
        {
            sedeRepository.Save(entity);
        }

        public void Update(Sede entity)
        {
            sedeRepository.Update(entity);
        }
    }
}
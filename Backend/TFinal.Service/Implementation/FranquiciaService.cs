using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class FranquiciaService : IFranquiciaService
    {
        private IFranquiciaRepository franquiciaRepository;

        public FranquiciaService(IFranquiciaRepository franquiciaRepository)
        {
            this.franquiciaRepository = franquiciaRepository;
        }

        public void Delete(Franquicia entity)
        {
            franquiciaRepository.Delete(entity);
        }

        public Franquicia FindById(Franquicia entity)
        {
            return franquiciaRepository.FindById(entity);
        }

        public List<Franquicia> ListAll()
        {
            return franquiciaRepository.ListAll();
        }

        public void Save(Franquicia entity)
        {
            franquiciaRepository.Save(entity);
        }

        public void Update(Franquicia entity)
        {
            franquiciaRepository.Update(entity);
        }
    }
}
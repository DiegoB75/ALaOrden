using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class DireccionService : IDireccionService
    {
        private IDireccionRepository direccionRepository;

        public DireccionService(IDireccionRepository direccionRepository)
        {
            this.direccionRepository = direccionRepository;
        }

        public void Delete(Direccion entity)
        {
            direccionRepository.Delete(entity);
        }

        public Direccion FindById(Direccion entity)
        {
            return direccionRepository.FindById(entity);
        }

        public List<Direccion> ListAll()
        {
            return direccionRepository.ListAll();
        }

        public void Save(Direccion entity)
        {
            direccionRepository.Save(entity);
        }

        public void Update(Direccion entity)
        {
            direccionRepository.Update(entity);
        }
    }
}
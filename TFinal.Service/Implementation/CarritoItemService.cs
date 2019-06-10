using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class CarritoItemService : ICarritoItemService
    {
        private ICarritoItemRepository carritoRepository;

        public CarritoItemService(ICarritoItemRepository carritoRepository)
        {
            this.carritoRepository = carritoRepository;
        }

        public void Delete(CarritoItem entity)
        {
            carritoRepository.Delete(entity);
        }

        public CarritoItem FindById(CarritoItem entity)
        {
            return carritoRepository.FindById(entity);
        }

        public List<CarritoItem> ListAll()
        {
            return carritoRepository.ListAll();
        }

        public List<CarritoItem> ListByUsuario(int idUsuario)
        {
            throw new System.NotImplementedException();
        }

        public void Save(CarritoItem entity)
        {
            carritoRepository.Save(entity);
        }

        public void Update(CarritoItem entity)
        {
            carritoRepository.Update(entity);
        }
    }
}
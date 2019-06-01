using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class CarritoService : ICarritoService
    {
        private ICarritoRepository carritoRepository;

        public CarritoService(ICarritoRepository carritoRepository)
        {
            this.carritoRepository = carritoRepository;
        }

        public void Delete(Carrito entity)
        {
            carritoRepository.Delete(entity);
        }

        public Carrito FindById(Carrito entity)
        {
            return carritoRepository.FindById(entity);
        }

        public List<Carrito> ListAll()
        {
            return carritoRepository.ListAll();
        }

        public void Save(Carrito entity)
        {
            carritoRepository.Save(entity);
        }

        public void Update(Carrito entity)
        {
            carritoRepository.Update(entity);
        }
    }
}
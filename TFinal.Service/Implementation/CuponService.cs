using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class CuponService : ICuponService
    {
        private ICuponRepository cuponRepository;

        public CuponService(ICuponRepository cuponRepository)
        {
            this.cuponRepository = cuponRepository;
        }

        public void Delete(Cupon entity)
        {
            cuponRepository.Delete(entity);
        }

        public Cupon FindById(Cupon entity)
        {
            return cuponRepository.FindById(entity);
        }

        public List<Cupon> ListAll()
        {
            return cuponRepository.ListAll();
        }

        public void Save(Cupon entity)
        {
            cuponRepository.Save(entity);
        }

        public void Update(Cupon entity)
        {
            cuponRepository.Update(entity);
        }
    }
}
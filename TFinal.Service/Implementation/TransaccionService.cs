using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class TransaccionService : ITransaccionService
    {
        private ITransaccionRepository transaccionRepository;

        public TransaccionService(ITransaccionRepository transaccionRepository)
        {
            this.transaccionRepository = transaccionRepository;
        }

        public void Delete(Transaccion entity)
        {
            transaccionRepository.Delete(entity);
        }

        public Transaccion FindById(Transaccion entity)
        {
            return transaccionRepository.FindById(entity);
        }

        public List<Transaccion> ListAll()
        {
            return transaccionRepository.ListAll();
        }

        public void Save(Transaccion entity)
        {
            transaccionRepository.Save(entity);
        }

        public void Update(Transaccion entity)
        {
            transaccionRepository.Update(entity);
        }
    }
}
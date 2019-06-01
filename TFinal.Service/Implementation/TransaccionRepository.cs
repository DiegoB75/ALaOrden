using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class TransaccionRepository : ITransaccionRepository
    {
        ApplicationDbContext context;
        public TransaccionRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Transaccion entity)
        {
            context.Transacciones.Remove(entity);
            context.SaveChanges();
        }

        public Transaccion FindById(Transaccion entity)
        {
            return context.Transacciones.FirstOrDefault(x => x.idTransaccion == entity.idTransaccion);
        }

        public List<Transaccion> ListAll()
        {
            return context.Transacciones.ToList();
        }

        public void Save(Transaccion entity)
        {
            context.Transacciones.Add(entity);
            context.SaveChanges();
        }

        public void Update(Transaccion entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
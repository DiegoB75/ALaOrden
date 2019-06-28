using System;
using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class PedidoRepository : IPedidoRepository
    {
        private ApplicationDbContext context;
        public PedidoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(Pedido entity)
        {
            context.Pedidos.Remove(entity);
            context.SaveChanges();
        }

        public Pedido FindById(Pedido entity)
        {
            return context.Pedidos.Include(x => x.Sede.Franquicia).Include(x => x.Transaccion).Include(x => x.DetallesPedidos).Include(x => x.Cupones).FirstOrDefault(x => x.IdPedido == entity.IdPedido);
        }

        public List<Pedido> ListAll()
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListByUsuario(int idUsuario)
        {
            return context.Pedidos.Where(x => x.IdUsuario == idUsuario).ToList();
        }

        public void Save(Pedido entity)
        {
            context.Pedidos.Add(entity);
            context.SaveChanges();
        }

        public void Update(Pedido entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
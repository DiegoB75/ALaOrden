using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Implementation
{
    public class DetallePedidoRepository : IDetallePedidoRepository
    {
        private ApplicationDbContext context;

        public DetallePedidoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Delete(DetallePedido entity)
        {
            context.DetallesPedido.Remove(entity);
            context.SaveChanges();
        }

        public DetallePedido FindById(DetallePedido entity)
        {
            return context.DetallesPedido.Include(x => x.Pedido).FirstOrDefault(x =>
                x.Pedido.IdPedido == entity.Pedido.IdPedido &&
                x.Producto.IdProducto == entity.Producto.IdProducto);
        }

        public List<DetallePedido> ListAll()
        {
            throw new System.NotImplementedException();
        }

        public List<DetallePedido> ListByPedido(int idPedido)
        {
            return context.DetallesPedido.Include(x => x.Pedido).Where(x => x.IdPedido == idPedido).ToList();
        }

        public void Save(DetallePedido entity)
        {
            context.DetallesPedido.Add(entity);
            context.SaveChanges();
        }

        public void Update(DetallePedido entity)
        {
            context.Entry(entity).State=EntityState.Modified;
            context.SaveChanges();
        }
    }
}
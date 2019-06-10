using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public void Delete(Pedido entity)
        {
            pedidoRepository.Delete(entity);
        }

        public Pedido FindById(Pedido entity)
        {
            return pedidoRepository.FindById(entity);
        }

        public List<Pedido> ListAll()
        {
            return pedidoRepository.ListAll();
        }

        public List<Pedido> ListByUsuario(int idUsuario)
        {
            return pedidoRepository.ListByUsuario(idUsuario);
        }

        public void Save(Pedido entity)
        {
            pedidoRepository.Save(entity);
        }

        public void Update(Pedido entity)
        {
            pedidoRepository.Update(entity);
        }
    }
}
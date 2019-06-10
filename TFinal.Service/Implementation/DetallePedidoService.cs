using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class DetallePedidoService : IDetallePedidoService
    {
        private IDetallePedidoRepository detallePedidoRepository;

        public DetallePedidoService(IDetallePedidoRepository detallePedidoRepository)
        {
            this.detallePedidoRepository = detallePedidoRepository;
        }

        public void Delete(DetallePedido entity)
        {
            detallePedidoRepository.Delete(entity);
        }

        public DetallePedido FindById(DetallePedido entity)
        {
            return detallePedidoRepository.FindById(entity);
        }

        public List<DetallePedido> ListAll()
        {
            return detallePedidoRepository.ListAll();
        }

        public List<DetallePedido> ListByPedido(int idPedido)
        {
            return detallePedidoRepository.ListByPedido(idPedido);
        }

        public void Save(DetallePedido entity)
        {
            detallePedidoRepository.Save(entity);
        }

        public void Update(DetallePedido entity)
        {
            detallePedidoRepository.Update(entity);
        }
    }
}
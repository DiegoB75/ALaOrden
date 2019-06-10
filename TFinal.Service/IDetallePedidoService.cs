using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Service
{
    public interface IDetallePedidoService : ICrudService<DetallePedido>
    {
        List<DetallePedido> ListByPedido(int idPedido);
    }
}
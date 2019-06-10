using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Repository
{
    public interface IDetallePedidoRepository : ICrudRepository<DetallePedido>
    {
        List<DetallePedido> ListByPedido(int idPedido);    
    }
}
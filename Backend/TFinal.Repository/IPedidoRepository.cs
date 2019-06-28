using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Repository
{
    public interface IPedidoRepository : ICrudRepository<Pedido>
    {
        List<Pedido> ListByUsuario(int idUsuario);
    }
}
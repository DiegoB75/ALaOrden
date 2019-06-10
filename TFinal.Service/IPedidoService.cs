using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Service
{
    public interface IPedidoService : ICrudService<Pedido>
    {
        List<Pedido> ListByUsuario(int idUsuario);
    }
}
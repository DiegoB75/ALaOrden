using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Service
{
    public interface IPedidoService : ICrudService<Pedido>
    {
        List<Pedido> ListByUsuario(int idUsuario);
         List<DetallePedido> GenerarListXFranquicia(List< CarritoItem > cart, Franquicia prov) ;
         List<Pedido> GenerateList(List< CarritoItem > cart, List<Sede> sedes);
    }
}
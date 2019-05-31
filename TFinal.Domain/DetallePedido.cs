using System;

namespace TFinal.Domain
{
    public class DetallePedido {
        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}

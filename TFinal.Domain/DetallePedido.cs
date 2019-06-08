using System;

namespace TFinal.Domain
{
    public class DetallePedido {
        public int IdPedido {get;set;}
        public Pedido Pedido { get; set; }
        public int IdProducto {get;set;}
        public Producto Producto { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
    }
}

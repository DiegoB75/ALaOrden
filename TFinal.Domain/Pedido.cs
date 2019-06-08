using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public Usuario Usuario { get; set; }
        public Sede Sede { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
        public string Direccion { get; set; }
        public Transaccion Transaccion { get; set; }
        public double SubTotal { get; set; }
        public double PrecioEnvio { get; set; }
        public double Descuento { get; set; }
        public ICollection<Cupon> Cupones { get; set; }
        public ICollection<DetallePedido> DetallesPedidos { get; set; }
    }
}

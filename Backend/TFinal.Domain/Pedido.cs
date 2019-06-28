using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public int IdSede { get; set; }
        public Sede Sede { get; set; }
        public string Estado { get; set; }
        public string Fecha { get; set; }
        public string Direccion { get; set; }
        public int IdTransaccion { get; set; }
        public Transaccion Transaccion { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PrecioEnvio { get; set; }
        public decimal Descuento { get; set; }
        public ICollection<Cupon> Cupones { get; set; }
        public ICollection<DetallePedido> DetallesPedidos { get; set; }
    }
}

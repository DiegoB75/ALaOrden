using System;

namespace TFinal.Domain
{
    public class Cupon
    {
        public int IdCupon { get; set; }
        public string Codigo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public bool Vigente { get; set; }
        public decimal Descuento { get; set; }
        public int? IdPedido { get; set;}
        public Pedido Pedido { get; set; }
    }
}
using System;

namespace TFinal.Domain
{
    //TODO: cambiar por nombre que no sea colectivo (Producto_Usuario(?))
    public class Carrito
    {
        public Usuario Usuario { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
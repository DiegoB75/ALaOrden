using System.Collections.Generic;
using System;

namespace TFinal.Domain
{
    //TODO: cambiar por nombre que no sea colectivo (Producto_Usuario(?))
    public class CarritoItem
    {
        public int IdUsuario {get;set;}
        public Usuario Usuario { get; set; }
        public int IdProducto {get;set;}
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
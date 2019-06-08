using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TFinal.Domain
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Apodo { get; set; }
        public string HashContrasena { get; set; }
        public string Sal { get; set; }
        //criptografia
        public string Email { get; set; }
        public bool EmailValidado { get; set; }
        public ICollection<Pedido> Pedidos {get; set;}
        public ICollection<Direccion> Direcciones { get; set; }
        public ICollection<CarritoItem> Carrito { get; set; }
    }
}

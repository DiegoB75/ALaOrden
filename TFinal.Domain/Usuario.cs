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
        public string Saldo { get; set; }
        public string Email { get; set; }
        public bool EmailValidado { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Carrito> Carrito { get; set; }
    }
}

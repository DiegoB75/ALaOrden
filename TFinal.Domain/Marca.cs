using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public List<Producto> Productos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class ProductoFranquicia
    {
        public Producto Producto { get; set; }
        public Franquicia Franquicia { get; set; }
        public string CodReferencia { get; set; }
    }
}

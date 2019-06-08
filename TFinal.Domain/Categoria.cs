using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public Categoria CategoriaPadre {get;set;}
        public ICollection<Producto> Productos { get; set; }
    }
}

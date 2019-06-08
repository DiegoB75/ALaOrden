using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Categoria
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public int? IdCategoriaPadre { get; set; }
        public Categoria CategoriaPadre { get; set; }
        public ICollection<Producto> Productos { get; set; }
        public ICollection<Categoria> SubCategorias { get; set; }
    }
}

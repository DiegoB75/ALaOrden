using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public int Cantidad { get; set; }
        //TODO: corregir Magnitud
        public double Magnitud { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public ICollection<ProductoFranquicia> ProductoFranquicias { get; set; }
    }
}

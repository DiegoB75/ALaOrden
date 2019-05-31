using System;

namespace TFinal.Domain
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Categoria Categoria { get; set; }
        public Marca Marca { get; set; }
        public string Nombre { get; set; }
        public string Presentacion { get; set; }
        public int Cantidad { get; set; }
        //TODO: corregir MAgnitud
        public double Magnitud { get; set; }
        public string Unidad { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
    }
}

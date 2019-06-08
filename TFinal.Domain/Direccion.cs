using System;

namespace TFinal.Domain
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public double Longitud { get; set; }

        public double Latitud { get; set; }

        public string Descripcion { get; set; }

    }
}

using System;

namespace TFinal.Domain
{
    public class Sede
    {
        public int IdSede { get; set; }
        public string Direccion { get; set; }
        public Franquicia Franquicia { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
    }
}

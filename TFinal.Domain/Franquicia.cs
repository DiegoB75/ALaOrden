﻿using System;
using System.Collections.Generic;

namespace TFinal.Domain
{
    public class Franquicia
    {
        public int IdFranquicia { get; set; }
        public string Nombre { get; set; }
        public string Url { get; set; }
        public string Conexion { get; set; }
        public string Logo { get; set; }
        public List<Sede> Sedes { get; set; }
        public List<ProductoFranquicia> ProductoFranquicias { get; set; }
        //TODO: Cambiar "ProductoFranquicia" por otra cosa (ProductosDisponibles)

    }
}

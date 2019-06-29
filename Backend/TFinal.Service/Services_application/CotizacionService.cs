using System;
using System.Net;
using Newtonsoft.Json;
using TFinal.Domain;
using TFinal.Repository;
using System.Collections.Generic;

namespace TFinal.Service.Services_application
{

    public class CotizacionService
    {
        public static string conexion = "http://localhost:4999";
        public List<DetallePedido> GenerarListXFranquicia(List< CarritoItem > cart, Franquicia prov) {
        List<DetallePedido> lista = new List<DetallePedido>();
        /*Dictionary<string,KeyValuePair<int,decimal> > listProv = new Dictionary<string,KeyValuePair<int,decimal> >();
        string url = conexion + prov.ApiUrl;
        //establecer conexion
        var json = new WebClient().DownloadString(url);
        dynamic m = JsonConvert.DeserializeObject(json);
        foreach (var item in m)
            {
                listProv[item.id] = new KeyValuePair <int, double>(item.stock, item.precio);
            }*/
        Random r = new Random();
        foreach (CarritoItem item in cart) {

            //empaquetar (incluir price)
            DetallePedido rpta = new DetallePedido{
                IdProducto = item.IdProducto,
                Precio = (decimal)49.99,
                Cantidad = item.Cantidad
            };
            lista.Add(rpta);
        }
        return lista;
    }
        public List<Pedido> GenerateList(List< CarritoItem > cart, List<Sede> sedes){
            List<Sede> proveedores = sedes;
            List<Pedido> cotizacion = new List<Pedido>();
            if(proveedores!=null && proveedores.Count>0)
            {
                foreach(Sede prov in proveedores){
                    List<DetallePedido> detalle = GenerarListXFranquicia(cart,prov.Franquicia);
                    Pedido p = new Pedido();
                    decimal subTotal = 0;
                    foreach(DetallePedido det in detalle){
                        subTotal = subTotal + det.Precio;
                    }
                    p.DetallesPedidos = detalle;
                    cotizacion.Add(p);
                }
            }
            return cotizacion;
        }
        
    }
}
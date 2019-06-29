using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            this.pedidoRepository = pedidoRepository;
        }

        public void Delete(Pedido entity)
        {
            pedidoRepository.Delete(entity);
        }

        public Pedido FindById(Pedido entity)
        {
            return pedidoRepository.FindById(entity);
        }

        public List<Pedido> ListAll()
        {
            return pedidoRepository.ListAll();
        }

        public List<Pedido> ListByUsuario(int idUsuario)
        {
            return pedidoRepository.ListByUsuario(idUsuario);
        }

        public void Save(Pedido entity)
        {
            pedidoRepository.Save(entity);
        }

        public void Update(Pedido entity)
        {
            pedidoRepository.Update(entity);
        }
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
                    p.Sede = prov;
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
using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using System;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class DireccionService : IDireccionService
    {
        private IDireccionRepository direccionRepository;
        private ISedeRepository sedeRepository;

        public DireccionService(IDireccionRepository direccionRepository,ISedeRepository sedeRepository)
        {
            this.direccionRepository = direccionRepository;
            this.sedeRepository = sedeRepository;
        }

        public void Delete(Direccion entity)
        {
            direccionRepository.Delete(entity);
        }

        public Direccion FindById(Direccion entity)
        {
            return direccionRepository.FindById(entity);
        }

        public List<Direccion> ListAll()
        {
            return direccionRepository.ListAll();
        }

        public List<Direccion> ListByUsuario(int idUsuario)
        {
            return direccionRepository.ListByUsuario(idUsuario);
        }

        public void Save(Direccion entity)
        {
            direccionRepository.Save(entity);
        }

        public void Update(Direccion entity)
        {
            direccionRepository.Update(entity);
        }
        public double computeDistance(double latA,double longA,double latB,double longB){
        /*var R = 6371; // Radius of the earth in km
        var dLat = deg2rad(lat2-lat1);  // deg2rad below
        var dLon = deg2rad(lon2-lon1);
        var a =
                Math.sin(dLat/2) * Math.sin(dLat/2) +
                        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
                                Math.sin(dLon/2) * Math.sin(dLon/2)
                ;
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a));
        var d = R * c; // Distance in km
        return d;*/

        double R = 6137;
        double dLat = (Math.PI/180.00)*(latB-latA);
        double dLong = (Math.PI/180.00)*(longB-longA);
        double a = Math.Sin(dLat/2)*Math.Sin(dLat/2)+Math.Cos((Math.PI/180.00)*(latA))*
        Math.Cos((Math.PI/180.00)*(latB))*Math.Sin(dLong/2)*Math.Sin(dLong/2);
        double c = 2*Math.Atan2(Math.Sqrt(a),Math.Sqrt(1-a));
        double d = R*c;
        return d;
    }
    public decimal computeDeliveryPrice(double distancia){
        return (decimal)(distancia*0.05 + 5.00);
    }
    public List<Pedido> LlenarDeliveryPrice(List<Pedido> pedidos , Direccion direccion){
        
        foreach(var ped in pedidos){
            if(ped!=null){
         double dist = computeDistance(direccion.Latitud,direccion.Longitud,ped.Sede.Latitud,ped.Sede.Longitud);
         decimal price = computeDeliveryPrice(dist);
         ped.PrecioEnvio = price;
         foreach(DetallePedido dp in ped.DetallesPedidos){
         ped.SubTotal = ped.SubTotal + dp.Precio*dp.Cantidad;

         }
            }
        }
        return pedidos;
    }
    public bool Exist(string s, List< string> ls){
        foreach(string franquicia in ls){
            if(s == franquicia)return true;
        }
        return false;
    }
        public List<Sede> ListDistanceMin(double latitud,double longitud){
        List<Sede> sedes = sedeRepository.ListAll();
        List<string> setLocations = new List<string>();

        List<Sede> selectedLocations = new List<Sede>();

        foreach(Sede sede in sedes){
            double dist = computeDistance(latitud,longitud,sede.Latitud,sede.Longitud);
            //if(dist <= 3.500) <--- distancia menor a 3.5 km
            
                if(!Exist(sede.Franquicia.Nombre,setLocations)){
                    selectedLocations.Add(sede);
                    setLocations.Add(sede.Franquicia.Nombre);
                }
            
        }
        return sedes;
    }
    }
}
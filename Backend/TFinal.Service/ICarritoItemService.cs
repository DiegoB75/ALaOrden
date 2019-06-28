using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Service
{
    public interface ICarritoItemService: ICrudService<CarritoItem>
    {
        List<CarritoItem> ListByUsuario(int idUsuario);
        void saveToCart(CarritoItem entity);
    void deleteFromCart(CarritoItem entity);
    void emptyCart(int id);
    }
}
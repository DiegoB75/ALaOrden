using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Repository
{
    public interface ICarritoItemRepository : ICrudRepository<CarritoItem>
    {
        List<CarritoItem> ListByUsuario(int idUsuario);
    }
}
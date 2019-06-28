using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Repository
{
    public interface IProductoFranquiciaRepository : ICrudRepository<ProductoFranquicia>
    {
         List<ProductoFranquicia> ListByProducto(int idProducto);
    }
}
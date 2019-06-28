using System.Collections.Generic;
using TFinal.Domain;

namespace TFinal.Service
{
    public interface IProductoFranquiciaService : ICrudService<ProductoFranquicia>
    {
         List<ProductoFranquicia> ListByProducto(int idProducto);
    }
}
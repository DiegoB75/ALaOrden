using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service
{
    public interface IProductoService : ICrudService<Producto>
    {
           
     List<Categoria> listCategories();
     List<Marca> listBrand();
     List<Producto> listProductsByCategoria(int id);
     List<Producto> listProductSearch(string name);
   
  
    }
}
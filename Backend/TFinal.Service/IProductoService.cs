using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service
{
    public interface IProductoService : ICrudService<Producto>
    {
           
     List<Categoria> ListCategories();
     List<Marca> ListBrand();
     List<Producto> ListProductsByCategoria(int id);
     List<Producto> ListProductSearch(string name);
        List<Producto> FindByNameandCategoryContaining(string name,int id);
  
    }
}
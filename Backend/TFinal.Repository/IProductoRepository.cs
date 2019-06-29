using System.Collections.Generic;
using TFinal.Domain;
using System.Linq;

using TFinal.Repository;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Repository
{
    public interface IProductoRepository : ICrudRepository<Producto>
    {
        List<Producto> FindAllByCategoryIdCategory(int id);

    List<Producto> FindByNameContaining(string name);
    List<Producto> FindByNameandCategoryContaining(string name,int id);
    }
}
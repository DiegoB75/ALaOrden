using System.Collections.Generic;
using TFinal.Domain;
using System.Linq;

using TFinal.Repository;
using Microsoft.EntityFrameworkCore;


namespace TFinal.Repository
{
    public interface IProductoRepository : ICrudRepository<Producto>
    {
        List<Producto> findAllByCategoryIdCategory(int id);

    List<Producto> findByNameContaining(string name);
    }
}
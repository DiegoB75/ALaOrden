using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
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
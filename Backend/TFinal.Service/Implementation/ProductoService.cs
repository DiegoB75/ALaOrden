using System.Collections.Generic;
using System.Linq;
using TFinal.Domain;
using TFinal.Repository;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Service.Implementation
{
    public class ProductoService : IProductoService
    {
        private IProductoRepository productoRepository;
         private ICategoriaRepository categoriaRepository;
         private IMarcaRepository marcaRepository;

        public ProductoService(IProductoRepository productoRepository,
        ICategoriaRepository categoriaRepository,
        IMarcaRepository marcaRepository)
        {
            this.productoRepository = productoRepository;
               this.categoriaRepository = categoriaRepository;
            this.marcaRepository = marcaRepository;

    }

        public void Delete(Producto entity)
        {
            productoRepository.Delete(entity);
        }

        public Producto FindById(Producto entity)
        {
            return productoRepository.FindById(entity);
        }

       
        public void Save(Producto entity)
        {
            productoRepository.Save(entity);
        }

        public void Update(Producto entity)
        {
            productoRepository.Update(entity);
        }

       
     public List<Producto> ListAll()
        {
            List<Producto> products = productoRepository.ListAll();
            return products;
        }
 public List<Categoria> listCategories()
        {
            List<Categoria> categorias = categoriaRepository.ListAll();
            return categorias;
        }

    public List<Marca> listBrand()
    {
          List<Marca> marcas = marcaRepository.ListAll();
            return marcas;
    }
    public List<Producto> listProductsByCategoria(int id)
    {
       
        List<Producto> products = productoRepository.findAllByCategoryIdCategory(id);

        return products;
           
    }
     public List<Producto> listProductSearch(string name)
     {
          List<Producto> products = productoRepository.findByNameContaining(name);
            return products;
     }
    }
}
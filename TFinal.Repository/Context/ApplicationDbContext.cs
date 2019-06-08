using TFinal.Domain;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CarritoItem
            modelBuilder.Entity<CarritoItem>()
                .HasKey(x => new { x.IdUsuario, x.IdProducto });
            modelBuilder.Entity<CarritoItem>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Carrito)
                .HasForeignKey(x => x.IdUsuario);
            modelBuilder.Entity<CarritoItem>()
                .HasOne(x => x.Producto)
                .WithMany().HasForeignKey(x=>x.IdProducto);
            
            //Categoria
            modelBuilder.Entity<Categoria>()
                .HasKey(x => x.IdCategoria);
            modelBuilder.Entity<Categoria>()
                .HasOne(x => x.CategoriaPadre)
                .WithMany().HasForeignKey(x => x.IdCategoria);
            
            //Cupon
            modelBuilder.Entity<Cupon>()
                .HasKey(x => x.IdCupon);
            modelBuilder.Entity<Cupon>()
                .HasOne(x => x.UsadoEnPedido)
                .WithMany(x => x.Cupones);

            //DetallePedido
            modelBuilder.Entity<CarritoItem>()
                .HasKey(x => new { x.IdUsuario, x.IdProducto });
            modelBuilder.Entity<CarritoItem>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Carrito)
                .HasForeignKey(x => x.IdUsuario);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(x => x.Producto)
                .WithMany().HasForeignKey(x=>x.IdProducto);
        }

        public DbSet<CarritoItem> Carritos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cupon> Cupones { get; set; }
        public DbSet<DetallePedido> DetallesPedido { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Franquicia> Franquicias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<ProductoFranquicia> ProductosFranquicias { get; set; }
        public DbSet<Sede> Sedes { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
    }
}
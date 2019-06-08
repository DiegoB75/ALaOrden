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
            modelBuilder.Entity<DetallePedido>()
                .HasKey(x => new { x.IdPedido, x.IdProducto });
            modelBuilder.Entity<DetallePedido>()
                .HasOne(x => x.Pedido)
                .WithMany(x => x.DetallesPedidos)
                .HasForeignKey(x => x.IdPedido);
            modelBuilder.Entity<DetallePedido>()
                .HasOne(x => x.Producto)
                .WithMany().HasForeignKey(x=>x.IdProducto);
            
            //Direccion
            modelBuilder.Entity<Direccion>()
                .HasKey(x => x.IdDireccion);
            modelBuilder.Entity<Direccion>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Direcciones);

            //Franquicia
            modelBuilder.Entity<Franquicia>()
                .HasKey(x => x.IdFranquicia);

            //Marca
            modelBuilder.Entity<Marca>()
                .HasKey(x => x.IdMarca);

            //Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(x => x.IdPedido);
            modelBuilder.Entity<Pedido>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Pedidos);
            modelBuilder.Entity<Pedido>()
                .HasOne(x => x.Transaccion)
                .WithOne();
            modelBuilder.Entity<Pedido>()
                .HasOne(x => x.Sede)
                .WithMany();

            //Producto
            modelBuilder.Entity<Producto>()
                .HasKey(x => x.IdProducto);
            modelBuilder.Entity<Producto>()
                .HasOne(x => x.Categoria)
                .WithMany(x => x.Productos);
            modelBuilder.Entity<Producto>()
                .HasOne(x => x.Marca)
                .WithMany(x => x.Productos);
            
            //ProductoFranquicia
            modelBuilder.Entity<ProductoFranquicia>()
                .HasKey(x => new { x.IdProducto, x.IdFranquicia});
            modelBuilder.Entity<ProductoFranquicia>()
                .HasOne(x => x.Producto)
                .WithMany(x => ProductosFranquicias)
                .HasForeignKey(x => x.IdProducto);
            modelBuilder.Entity<ProductoFranquicia>()
                .HasOne(x => x.Franquicia)
                .WithMany(x => ProductosFranquicias)
                .HasForeignKey(x => x.IdFranquicia);

            //Sede
            modelBuilder.Entity<Sede>()
                .HasKey(x => x.IdSede);
            modelBuilder.Entity<Sede>()
                .HasOne(x => x.Franquicia)
                .WithMany(x => x.Sedes);

            //Transaccion
            modelBuilder.Entity<Transaccion>()
                .HasKey(x => x.idTransaccion);

            //Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(x => x.IdUsuario);
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
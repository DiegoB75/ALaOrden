using TFinal.Domain;
using Microsoft.EntityFrameworkCore;

namespace TFinal.Repository.Context
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //CarritoItem
            modelBuilder.Entity<CarritoItem>(c => {
                c.ToTable("CarritoItem"); //nombre de tabla
                c.HasKey(x => new { x.IdUsuario, x.IdProducto }); //PK (composite)
                c.HasOne(x => x.Usuario)    //FK (manytoone)
                    .WithMany(x => x.Carrito)
                    .HasForeignKey(x => x.IdUsuario);
                c.HasOne(x => x.Producto)   //FK (manytoone)
                    .WithMany()
                    .HasForeignKey(x => x.IdProducto);
            });

            //Categoria
            modelBuilder.Entity<Categoria>(c => {
                c.ToTable("Categoria"); //nombre de tabla
                c.HasKey(x => x.IdCategoria);   //PK
                c.Property(x => x.IdCategoria)  //Identity
                    .ValueGeneratedOnAdd();
                c.HasOne(x => x.CategoriaPadre) //FK (manytoone)
                    .WithMany(x => x.SubCategorias)
                    .HasForeignKey(x => x.IdCategoriaPadre)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.Restrict);
            });
         
            //Cupon
            modelBuilder.Entity<Cupon>(c => {
                c.ToTable("Cupon");
                c.HasKey(x => x.IdCupon);
                c.Property(x => x.IdCupon)
                    .ValueGeneratedOnAdd();
                c.HasOne(x => x.Pedido)
                    .WithMany(x => x.Cupones)
                    .HasForeignKey(x => x.IdPedido);
                c.Property(x => x.Descuento)
                    .HasColumnType("decimal(5,2)");
            });                

            //DetallePedido
            modelBuilder.Entity<DetallePedido>(d => {
                d.ToTable("DetallePedido");
                d.HasKey(x => new { x.IdPedido, x.IdProducto });
                d.HasOne(x => x.Pedido)
                    .WithMany(x => x.DetallesPedidos)
                    .HasForeignKey(x => x.IdPedido);
                d.HasOne(x => x.Producto)
                    .WithMany()
                    .HasForeignKey(x => x.IdProducto);
                d.Property(x => x.Precio)
                    .HasColumnType("decimal(5,2)");
            });
                
            //Direccion
            modelBuilder.Entity<Direccion>(d => {
                d.ToTable("Direccion");
                d.HasKey(x => x.IdDireccion);
                d.Property(x => x.IdDireccion)
                    .ValueGeneratedOnAdd();
                d.HasOne(x => x.Usuario)
                    .WithMany(x => x.Direcciones)
                    .HasForeignKey(x => x.IdUsuario);
            });

            //Franquicia
            modelBuilder.Entity<Franquicia>(f => {
                f.ToTable("Franquicia");
                f.HasKey(x => x.IdFranquicia);
                f.Property(x => x.IdFranquicia)
                    .ValueGeneratedOnAdd();
            });                

            //Marca
            modelBuilder.Entity<Marca>(m => {
                m.ToTable("Marca");
                m.HasKey(x => x.IdMarca);
                m.Property(x => x.IdMarca)
                    .ValueGeneratedOnAdd();
            });                

            //Pedido
            modelBuilder.Entity<Pedido>(p => {
                p.ToTable("Pedido");
                p.HasKey(x => x.IdPedido);
                p.Property(x => x.IdPedido)
                    .ValueGeneratedOnAdd();
                p.HasOne(x => x.Usuario)
                    .WithMany(x => x.Pedidos)
                    .HasForeignKey(x => x.IdUsuario);
                p.HasOne(x => x.Transaccion)
                    .WithOne()
                    .HasForeignKey<Pedido>(x => x.IdTransaccion);
                p.HasOne(x => x.Sede)
                    .WithMany()
                    .HasForeignKey(x => x.IdSede);
                p.Property(x => x.SubTotal)
                    .HasColumnType("decimal(7,2)");
                p.Property(x => x.PrecioEnvio)
                    .HasColumnType("decimal(7,2)");
                p.Property(x => x.Descuento)
                    .HasColumnType("decimal(7,2)");
            });            

            //Producto
            modelBuilder.Entity<Producto>(p => {
                p.ToTable("Producto");
                p.HasKey(x => x.IdProducto);
                p.Property(x => x.IdProducto)
                    .ValueGeneratedOnAdd();
                p.HasOne(x => x.Categoria)
                    .WithMany(x => x.Productos)
                    .HasForeignKey(x => x.IdCategoria);
                p.HasOne(x => x.Marca)
                    .WithMany(x => x.Productos)
                    .HasForeignKey(x => x.IdMarca);
            });
              
            //ProductoFranquicia
            modelBuilder.Entity<ProductoFranquicia>(p => {
                p.ToTable("ProductoFranquicia");
                p.HasKey(x => new { x.IdProducto, x.IdFranquicia });
                p.HasOne(x => x.Producto)
                    .WithMany(x => x.ProductoFranquicias)
                    .HasForeignKey(x => x.IdProducto);
                p.HasOne(x => x.Franquicia)
                    .WithMany(x => x.ProductoFranquicias)
                    .HasForeignKey(x => x.IdFranquicia);
            });

            //Sede
            modelBuilder.Entity<Sede>(s => {
                s.ToTable("Sede");
                s.HasKey(x => x.IdSede);
                s.Property(x => x.IdSede)
                    .ValueGeneratedOnAdd();
                s.HasOne(x => x.Franquicia)
                    .WithMany(x => x.Sedes)
                    .HasForeignKey(x => x.IdFranquicia);
            });                

            //Transaccion
            modelBuilder.Entity<Transaccion>(t => {
                t.ToTable("Transaccion");
                t.HasKey(x => x.IdTransaccion);
                t.Property(x => x.IdTransaccion)
                    .ValueGeneratedOnAdd();
            });

            //Usuario
            modelBuilder.Entity<Usuario>(u => {
                u.ToTable("Usuario");
                u.HasKey(x => x.IdUsuario);
                u.Property(x => x.IdUsuario)
                    .ValueGeneratedOnAdd();
            });
        }

        public DbSet<CarritoItem> CarritoItems { get; set; }
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
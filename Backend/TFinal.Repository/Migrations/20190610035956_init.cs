using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFinal.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    IdCategoriaPadre = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                    table.ForeignKey(
                        name: "FK_Categoria_Categoria_IdCategoriaPadre",
                        column: x => x.IdCategoriaPadre,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Franquicia",
                columns: table => new
                {
                    IdFranquicia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true),
                    WebUrl = table.Column<string>(nullable: true),
                    ApiUrl = table.Column<string>(nullable: true),
                    Logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Franquicia", x => x.IdFranquicia);
                });

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    IdMarca = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.IdMarca);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    IdTransaccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CardNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.IdTransaccion);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apodo = table.Column<string>(nullable: true),
                    HashContrasena = table.Column<string>(nullable: true),
                    Sal = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailValidado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    IdSede = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(nullable: true),
                    IdFranquicia = table.Column<int>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Latitud = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.IdSede);
                    table.ForeignKey(
                        name: "FK_Sede_Franquicia_IdFranquicia",
                        column: x => x.IdFranquicia,
                        principalTable: "Franquicia",
                        principalColumn: "IdFranquicia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCategoria = table.Column<int>(nullable: false),
                    IdMarca = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Presentacion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Magnitud = table.Column<double>(nullable: false),
                    Unidad = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Imagen = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Marca_IdMarca",
                        column: x => x.IdMarca,
                        principalTable: "Marca",
                        principalColumn: "IdMarca",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Direccion",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    Longitud = table.Column<double>(nullable: false),
                    Latitud = table.Column<double>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direccion_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdSede = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(nullable: true),
                    Fecha = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    IdTransaccion = table.Column<int>(nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    PrecioEnvio = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(7,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_Pedido_Sede_IdSede",
                        column: x => x.IdSede,
                        principalTable: "Sede",
                        principalColumn: "IdSede",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Transaccion_IdTransaccion",
                        column: x => x.IdTransaccion,
                        principalTable: "Transaccion",
                        principalColumn: "IdTransaccion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarritoItem",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarritoItem", x => new { x.IdUsuario, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_CarritoItem_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarritoItem_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductoFranquicia",
                columns: table => new
                {
                    IdProducto = table.Column<int>(nullable: false),
                    IdFranquicia = table.Column<int>(nullable: false),
                    CodReferencia = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoFranquicia", x => new { x.IdProducto, x.IdFranquicia });
                    table.ForeignKey(
                        name: "FK_ProductoFranquicia_Franquicia_IdFranquicia",
                        column: x => x.IdFranquicia,
                        principalTable: "Franquicia",
                        principalColumn: "IdFranquicia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoFranquicia_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cupon",
                columns: table => new
                {
                    IdCupon = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigo = table.Column<string>(nullable: true),
                    FechaEmision = table.Column<DateTime>(nullable: false),
                    FechaExpiracion = table.Column<DateTime>(nullable: false),
                    Vigente = table.Column<bool>(nullable: false),
                    Descuento = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IdPedido = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cupon", x => x.IdCupon);
                    table.ForeignKey(
                        name: "FK_Cupon_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    IdPedido = table.Column<int>(nullable: false),
                    IdProducto = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Cantidad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => new { x.IdPedido, x.IdProducto });
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_IdPedido",
                        column: x => x.IdPedido,
                        principalTable: "Pedido",
                        principalColumn: "IdPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarritoItem_IdProducto",
                table: "CarritoItem",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_IdCategoriaPadre",
                table: "Categoria",
                column: "IdCategoriaPadre");

            migrationBuilder.CreateIndex(
                name: "IX_Cupon_IdPedido",
                table: "Cupon",
                column: "IdPedido");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_IdProducto",
                table: "DetallePedido",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_IdUsuario",
                table: "Direccion",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdSede",
                table: "Pedido",
                column: "IdSede");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdTransaccion",
                table: "Pedido",
                column: "IdTransaccion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdUsuario",
                table: "Pedido",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdMarca",
                table: "Producto",
                column: "IdMarca");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoFranquicia_IdFranquicia",
                table: "ProductoFranquicia",
                column: "IdFranquicia");

            migrationBuilder.CreateIndex(
                name: "IX_Sede_IdFranquicia",
                table: "Sede",
                column: "IdFranquicia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarritoItem");

            migrationBuilder.DropTable(
                name: "Cupon");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Direccion");

            migrationBuilder.DropTable(
                name: "ProductoFranquicia");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Franquicia");
        }
    }
}

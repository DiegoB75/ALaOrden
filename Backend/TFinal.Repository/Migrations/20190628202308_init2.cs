using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TFinal.Repository.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "Pedido",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "Pedido",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}

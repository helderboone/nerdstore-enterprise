using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Pedidos.Infra.Migrations
{
    public partial class Corrigeclienteid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Pedidos");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Pedidos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedidos");

            migrationBuilder.AddColumn<Guid>(
                name: "ClientId",
                table: "Pedidos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}

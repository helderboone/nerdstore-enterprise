using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Carrinho.API.Migrations
{
    public partial class Voucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "CarrinhoClientes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "VoucherUtilizado",
                table: "CarrinhoClientes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCodigo",
                table: "CarrinhoClientes",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Percentual",
                table: "CarrinhoClientes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDesconto",
                table: "CarrinhoClientes",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDesconto",
                table: "CarrinhoClientes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "VoucherUtilizado",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "VoucherCodigo",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "Percentual",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "TipoDesconto",
                table: "CarrinhoClientes");

            migrationBuilder.DropColumn(
                name: "ValorDesconto",
                table: "CarrinhoClientes");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharkWallet_2._0.Migrations
{
    public partial class migracion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monedas_Billetera_Monedas",
                table: "Monedas");

            migrationBuilder.DropIndex(
                name: "IX_Monedas_Monedas",
                table: "Monedas");

            migrationBuilder.DropColumn(
                name: "Monedas",
                table: "Monedas");

            migrationBuilder.AddColumn<double>(
                name: "Moneda",
                table: "Billetera",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Moneda",
                table: "Billetera");

            migrationBuilder.AddColumn<int>(
                name: "Monedas",
                table: "Monedas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_Monedas",
                table: "Monedas",
                column: "Monedas");

            migrationBuilder.AddForeignKey(
                name: "FK_Monedas_Billetera_Monedas",
                table: "Monedas",
                column: "Monedas",
                principalTable: "Billetera",
                principalColumn: "BilleteraID");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharkWallet_2._0.Migrations
{
    public partial class sw201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    BalanceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<double>(type: "float", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.BalanceID);
                });

            migrationBuilder.CreateTable(
                name: "Billetera",
                columns: table => new
                {
                    BilleteraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Billetera", x => x.BilleteraID);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    MonedasID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonedasNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: true),
                    Monedas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.MonedasID);
                    table.ForeignKey(
                        name: "FK_Monedas_Balances_Balance",
                        column: x => x.Balance,
                        principalTable: "Balances",
                        principalColumn: "BalanceID");
                    table.ForeignKey(
                        name: "FK_Monedas_Billetera_Monedas",
                        column: x => x.Monedas,
                        principalTable: "Billetera",
                        principalColumn: "BilleteraID");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Billetera = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.UsuarioID);
                    table.ForeignKey(
                        name: "FK_Usuario_Billetera_Billetera",
                        column: x => x.Billetera,
                        principalTable: "Billetera",
                        principalColumn: "BilleteraID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_Balance",
                table: "Monedas",
                column: "Balance");

            migrationBuilder.CreateIndex(
                name: "IX_Monedas_Monedas",
                table: "Monedas",
                column: "Monedas");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Billetera",
                table: "Usuario",
                column: "Billetera");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropTable(
                name: "Billetera");
        }
    }
}

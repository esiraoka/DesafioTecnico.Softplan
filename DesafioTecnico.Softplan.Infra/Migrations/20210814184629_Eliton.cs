using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTecnico.Softplan.Infra.Migrations
{
    public partial class Eliton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juros",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Porcentagem = table.Column<decimal>(type: "numeric(3,2)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime", nullable: false, defaultValue: new DateTime(2021, 8, 14, 15, 46, 29, 341, DateTimeKind.Local).AddTicks(6817))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juros", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Juros");
        }
    }
}

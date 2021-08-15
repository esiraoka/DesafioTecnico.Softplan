using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTecnico.Softplan.Infra.Migrations
{
    public partial class ElitonAlteracaoTipoColuna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentagem",
                table: "Juros",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Juros",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 14, 18, 57, 6, 998, DateTimeKind.Local).AddTicks(9848),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 8, 14, 15, 46, 29, 341, DateTimeKind.Local).AddTicks(6817));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentagem",
                table: "Juros",
                type: "numeric(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Juros",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 14, 15, 46, 29, 341, DateTimeKind.Local).AddTicks(6817),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 8, 14, 18, 57, 6, 998, DateTimeKind.Local).AddTicks(9848));
        }
    }
}

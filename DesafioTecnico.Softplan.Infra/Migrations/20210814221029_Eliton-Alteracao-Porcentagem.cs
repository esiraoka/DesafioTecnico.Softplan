using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DesafioTecnico.Softplan.Infra.Migrations
{
    public partial class ElitonAlteracaoPorcentagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentagem",
                table: "Juros",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Juros",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 14, 19, 10, 28, 624, DateTimeKind.Local).AddTicks(4597),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 8, 14, 18, 57, 6, 998, DateTimeKind.Local).AddTicks(9848));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Porcentagem",
                table: "Juros",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataCadastro",
                table: "Juros",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(2021, 8, 14, 18, 57, 6, 998, DateTimeKind.Local).AddTicks(9848),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValue: new DateTime(2021, 8, 14, 19, 10, 28, 624, DateTimeKind.Local).AddTicks(4597));
        }
    }
}

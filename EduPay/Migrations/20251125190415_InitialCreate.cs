using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduPay.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPagamento",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "MetodoPagamento",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "DataMatricula",
                table: "Matriculas");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Cursos",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Cursos",
                newName: "Nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "Cursos",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Cursos",
                newName: "Preco");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPagamento",
                table: "Pagamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MetodoPagamento",
                table: "Pagamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Pagamentos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataMatricula",
                table: "Matriculas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}

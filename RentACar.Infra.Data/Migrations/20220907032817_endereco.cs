using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentACar.Infra.Data.Migrations
{
    public partial class endereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Uf = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    ProprietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Proprietarios_ProprietarioId",
                        column: x => x.ProprietarioId,
                        principalTable: "Proprietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ProprietarioId",
                table: "Enderecos",
                column: "ProprietarioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}

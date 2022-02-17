using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Entity.Migrations
{
    public partial class Remodelagem_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_enderecos_clientes_clienteid",
                table: "enderecos");

            migrationBuilder.DropIndex(
                name: "IX_enderecos_clienteid",
                table: "enderecos");

            migrationBuilder.DropColumn(
                name: "clienteid",
                table: "enderecos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "clienteid",
                table: "enderecos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_enderecos_clienteid",
                table: "enderecos",
                column: "clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_enderecos_clientes_clienteid",
                table: "enderecos",
                column: "clienteid",
                principalTable: "clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

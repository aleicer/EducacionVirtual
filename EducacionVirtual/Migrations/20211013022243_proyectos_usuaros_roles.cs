using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityG44Edu.Migrations
{
    public partial class proyectos_usuaros_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdAcudientes",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAcudientes",
                table: "Estudiantes");
        }
    }
}

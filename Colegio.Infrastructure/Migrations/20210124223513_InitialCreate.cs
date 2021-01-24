using Microsoft.EntityFrameworkCore.Migrations;

namespace Colegio.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ingreso",
                columns: table => new
                {
                    IngresoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 20, nullable: true),
                    Apellido = table.Column<string>(maxLength: 20, nullable: true),
                    Identificacion = table.Column<string>(maxLength: 10, nullable: true),
                    Edad = table.Column<string>(maxLength: 2, nullable: true),
                    Casa = table.Column<string>(maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingreso", x => x.IngresoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingreso");
        }
    }
}

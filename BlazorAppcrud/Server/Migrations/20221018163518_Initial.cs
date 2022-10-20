using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppcrud.Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "id", "Name", "Role", "age", "city" },
                values: new object[] { 1, "Madhu Kumar", "Student", 20, "Chamarajanagar" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "id", "Name", "Role", "age", "city" },
                values: new object[] { 2, "Madhu", "Student", 20, "Mysore" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}

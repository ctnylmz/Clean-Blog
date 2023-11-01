using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Blog.Migrations
{
    public partial class DbSetFooter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Link3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footers");
        }
    }
}

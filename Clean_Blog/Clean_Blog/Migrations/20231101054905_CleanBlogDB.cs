using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Blog.Migrations
{
    public partial class CleanBlogDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Headers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Menu1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Menu2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Menu3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Menu4 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Headers");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Blog.Migrations
{
    public partial class HeaderForMenu5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Menu5",
                table: "Headers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Menu5",
                table: "Headers");
        }
    }
}

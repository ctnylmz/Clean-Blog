using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean_Blog.Migrations
{
    public partial class UpdateEnterToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Enters",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enters_UserId",
                table: "Enters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enters_AspNetUsers_UserId",
                table: "Enters",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enters_AspNetUsers_UserId",
                table: "Enters");

            migrationBuilder.DropIndex(
                name: "IX_Enters_UserId",
                table: "Enters");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Enters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}

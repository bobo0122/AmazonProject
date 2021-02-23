using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonProject.Migrations
{
    public partial class Bookss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Classification_Category",
                table: "Books",
                newName: "Classification");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Page",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Page",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Classification",
                table: "Books",
                newName: "Classification_Category");
        }
    }
}

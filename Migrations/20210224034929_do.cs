using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonProject.Migrations
{
    public partial class @do : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Page",
                table: "Books",
                newName: "PageNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PageNo",
                table: "Books",
                newName: "Page");
        }
    }
}

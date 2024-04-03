using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebSite.Context.Migrations
{
    public partial class AddImgArToCat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgURLAr",
                table: "categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgURLAr",
                table: "categories");
        }
    }
}

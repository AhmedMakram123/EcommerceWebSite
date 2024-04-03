using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebSite.Context.Migrations
{
    public partial class AddImgAr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgURLAr",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgURLAr",
                table: "products");
        }
    }
}

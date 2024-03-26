using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebSite.Context.Migrations
{
    public partial class EnNameAndARName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubCategores",
                newName: "EnName");

            migrationBuilder.AddColumn<string>(
                name: "ArName",
                table: "SubCategores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArName",
                table: "SubCategores");

            migrationBuilder.RenameColumn(
                name: "EnName",
                table: "SubCategores",
                newName: "Name");
        }
    }
}

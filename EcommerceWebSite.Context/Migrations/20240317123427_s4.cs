using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceWebSite.Context.Migrations
{
    public partial class s4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_carts_AspNetUsers_CustId",
                table: "carts");

            migrationBuilder.DropForeignKey(
                name: "FK_carts_products_ProductId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_CustId",
                table: "carts");

            migrationBuilder.DropIndex(
                name: "IX_carts_ProductId",
                table: "carts");

            migrationBuilder.AlterColumn<string>(
                name: "CustId",
                table: "carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_carts_CartId",
                table: "AspNetUsers",
                column: "CartId",
                principalTable: "carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_carts_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CartId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "CustId",
                table: "carts",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_carts_CustId",
                table: "carts",
                column: "CustId",
                unique: true,
                filter: "[CustId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_carts_ProductId",
                table: "carts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_carts_AspNetUsers_CustId",
                table: "carts",
                column: "CustId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_carts_products_ProductId",
                table: "carts",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_ProductBillDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBillDetails_ProductAttributes_ProductAttributeId",
                table: "ProductBillDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductBillDetails_ProductAttributeId",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "ProductAttributeId",
                table: "ProductBillDetails");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductBillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBillDetails_ProductId",
                table: "ProductBillDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBillDetails_Products_ProductId",
                table: "ProductBillDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductBillDetails_Products_ProductId",
                table: "ProductBillDetails");

            migrationBuilder.DropIndex(
                name: "IX_ProductBillDetails_ProductId",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductBillDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductAttributeId",
                table: "ProductBillDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductBillDetails_ProductAttributeId",
                table: "ProductBillDetails",
                column: "ProductAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBillDetails_ProductAttributes_ProductAttributeId",
                table: "ProductBillDetails",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

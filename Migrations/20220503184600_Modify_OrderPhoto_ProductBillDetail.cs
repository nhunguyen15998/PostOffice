using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_OrderPhoto_ProductBillDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPhotos_OrderDetails_OrderId",
                table: "OrderPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBillDetails_ProductAttributes_ProductAttributeId",
                table: "ProductBillDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductAttributeId",
                table: "ProductBillDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPhotos_Orders_OrderId",
                table: "OrderPhotos",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBillDetails_ProductAttributes_ProductAttributeId",
                table: "ProductBillDetails",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderPhotos_Orders_OrderId",
                table: "OrderPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductBillDetails_ProductAttributes_ProductAttributeId",
                table: "ProductBillDetails");

            migrationBuilder.AlterColumn<int>(
                name: "ProductAttributeId",
                table: "ProductBillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderPhotos_OrderDetails_OrderId",
                table: "OrderPhotos",
                column: "OrderId",
                principalTable: "OrderDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductBillDetails_ProductAttributes_ProductAttributeId",
                table: "ProductBillDetails",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_Bill_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_SenderId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SenderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromCityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromCountryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromProvinceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromWardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BillOrders");

            migrationBuilder.RenameColumn(
                name: "SenderId",
                table: "Orders",
                newName: "Status");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductBills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Length",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "ProductBillDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromAddress",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCityId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromProvinceId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromWardId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_BranchId",
                table: "Bills",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_SenderId",
                table: "Bills",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Branches_BranchId",
                table: "Bills",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_SenderId",
                table: "Bills",
                column: "SenderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Branches_BranchId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_SenderId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_BranchId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_SenderId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductBills");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "Length",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "FromAddress",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "FromCityId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "FromProvinceId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "FromWardId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "SenderId");

            migrationBuilder.AddColumn<string>(
                name: "FromAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FromCityId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromCountryId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromProvinceId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FromWardId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BillOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderId",
                table: "Orders",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_SenderId",
                table: "Orders",
                column: "SenderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}

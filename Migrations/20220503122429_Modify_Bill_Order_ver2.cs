using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_Bill_Order_ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Customers_SenderId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_ReceiverId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Users_ShipperId",
                table: "OrderTrackings");

            migrationBuilder.DropIndex(
                name: "IX_Bills_SenderId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                table: "Bills");

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
                name: "OrderQty",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderFirstName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderLastName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderPhone",
                table: "Bills");

            migrationBuilder.AlterColumn<int>(
                name: "ShipperId",
                table: "OrderTrackings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderFirstName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenderLastName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SenderId",
                table: "Orders",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_ReceiverId",
                table: "Orders",
                column: "ReceiverId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_SenderId",
                table: "Orders",
                column: "SenderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Users_ShipperId",
                table: "OrderTrackings",
                column: "ShipperId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_ReceiverId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_SenderId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderTrackings_Users_ShipperId",
                table: "OrderTrackings");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SenderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromCityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromProvinceId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FromWardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderFirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderLastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SenderPhone",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "ShipperId",
                table: "OrderTrackings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReceiverId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CompanyPhone",
                table: "Bills",
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
                name: "OrderQty",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderFirstName",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Bills",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SenderLastName",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderPhone",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_SenderId",
                table: "Bills",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Customers_SenderId",
                table: "Bills",
                column: "SenderId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_ReceiverId",
                table: "Orders",
                column: "ReceiverId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderTrackings_Users_ShipperId",
                table: "OrderTrackings",
                column: "ShipperId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

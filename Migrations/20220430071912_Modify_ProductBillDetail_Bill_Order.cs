using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_ProductBillDetail_Bill_Order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductBillDetails");

            migrationBuilder.DropColumn(
                name: "TotalOrder",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReceiverPhone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

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
                name: "SenderEmail",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SenderFirstName",
                table: "Bills",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ReceiverPhone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "CompanyPhone",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderFirstName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderLastName",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "SenderPhone",
                table: "Bills");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ProductBillDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalOrder",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}

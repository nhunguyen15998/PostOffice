using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_Order_Bill_ver3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Orders_FromCityId",
                table: "Orders",
                column: "FromCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FromProvinceId",
                table: "Orders",
                column: "FromProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FromWardId",
                table: "Orders",
                column: "FromWardId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ToCityId",
                table: "Orders",
                column: "ToCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ToProvinceId",
                table: "Orders",
                column: "ToProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ToWardId",
                table: "Orders",
                column: "ToWardId");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_ServiceId",
                table: "Bills",
                column: "ServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Services_ServiceId",
                table: "Bills",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_VNCities_FromCityId",
                table: "Orders",
                column: "FromCityId",
                principalTable: "VNCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_VNCities_ToCityId",
                table: "Orders",
                column: "ToCityId",
                principalTable: "VNCities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_VNStates_FromProvinceId",
                table: "Orders",
                column: "FromProvinceId",
                principalTable: "VNStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_VNStates_ToProvinceId",
                table: "Orders",
                column: "ToProvinceId",
                principalTable: "VNStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_VNWards_FromWardId",
                table: "Orders",
                column: "FromWardId",
                principalTable: "VNWards",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_VNWards_ToWardId",
                table: "Orders",
                column: "ToWardId",
                principalTable: "VNWards",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Services_ServiceId",
                table: "Bills");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_VNCities_FromCityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_VNCities_ToCityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_VNStates_FromProvinceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_VNStates_ToProvinceId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_VNWards_FromWardId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_VNWards_ToWardId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FromCityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FromProvinceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_FromWardId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ToCityId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ToProvinceId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ToWardId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Bills_ServiceId",
                table: "Bills");
        }
    }
}

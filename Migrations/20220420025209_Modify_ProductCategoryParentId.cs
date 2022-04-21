using Microsoft.EntityFrameworkCore.Migrations;

namespace post_office.Migrations
{
    public partial class Modify_ProductCategoryParentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ProductCategories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "ProductCategories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

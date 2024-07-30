using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductAreaUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductAreaId",
                table: "Product",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductAreaId",
                table: "Product",
                column: "ProductAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductArea_ProductAreaId",
                table: "Product",
                column: "ProductAreaId",
                principalTable: "ProductArea",
                principalColumn: "ProductAreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductArea_ProductAreaId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductAreaId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductAreaId",
                table: "Product");
        }
    }
}

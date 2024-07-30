using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductAreaRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_ProductArea_ProductId",
                table: "ProductArea",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductArea_Product_ProductId",
                table: "ProductArea",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductArea_Product_ProductId",
                table: "ProductArea");

            migrationBuilder.DropIndex(
                name: "IX_ProductArea_ProductId",
                table: "ProductArea");

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
    }
}

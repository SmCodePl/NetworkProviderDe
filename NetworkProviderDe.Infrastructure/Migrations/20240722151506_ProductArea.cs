using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NetAreaFiberPlan");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "Product",
                newName: "ProductId");

            migrationBuilder.CreateTable(
                name: "ProductArea",
                columns: table => new
                {
                    ProductAreaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductArea", x => x.ProductAreaId);
                    table.ForeignKey(
                        name: "FK_ProductArea_NetArea_AreaId",
                        column: x => x.AreaId,
                        principalTable: "NetArea",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductArea_AreaId",
                table: "ProductArea",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductArea");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Product",
                newName: "PlanId");

            migrationBuilder.CreateTable(
                name: "NetAreaFiberPlan",
                columns: table => new
                {
                    AreaFiberPlanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetAreaFiberPlan", x => x.AreaFiberPlanId);
                    table.ForeignKey(
                        name: "FK_NetAreaFiberPlan_NetArea_AreaId",
                        column: x => x.AreaId,
                        principalTable: "NetArea",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NetAreaFiberPlan_AreaId",
                table: "NetAreaFiberPlan",
                column: "AreaId");
        }
    }
}

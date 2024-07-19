using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relationToNetPlan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FiberNetPlan_NetAreaFiberPlan_NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan");

            migrationBuilder.DropIndex(
                name: "IX_FiberNetPlan_NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan");

            migrationBuilder.DropColumn(
                name: "NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FiberNetPlan_NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan",
                column: "NetAreaFiberPlanAreaFiberPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_FiberNetPlan_NetAreaFiberPlan_NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan",
                column: "NetAreaFiberPlanAreaFiberPlanId",
                principalTable: "NetAreaFiberPlan",
                principalColumn: "AreaFiberPlanId");
        }
    }
}

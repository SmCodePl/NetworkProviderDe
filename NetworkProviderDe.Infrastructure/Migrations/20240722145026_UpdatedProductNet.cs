using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductNet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProviderName",
                table: "FiberNetPlan",
                newName: "SiteB");

            migrationBuilder.RenameColumn(
                name: "PlanSpeed",
                table: "FiberNetPlan",
                newName: "TdcOtc");

            migrationBuilder.RenameColumn(
                name: "PlanPrice",
                table: "FiberNetPlan",
                newName: "ProductPrice");

            migrationBuilder.RenameColumn(
                name: "PlanName",
                table: "FiberNetPlan",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "PlanDescription",
                table: "FiberNetPlan",
                newName: "ProductDescription");

            migrationBuilder.AddColumn<int>(
                name: "Mrc",
                table: "FiberNetPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Speed",
                table: "FiberNetPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mrc",
                table: "FiberNetPlan");

            migrationBuilder.DropColumn(
                name: "Speed",
                table: "FiberNetPlan");

            migrationBuilder.RenameColumn(
                name: "TdcOtc",
                table: "FiberNetPlan",
                newName: "PlanSpeed");

            migrationBuilder.RenameColumn(
                name: "SiteB",
                table: "FiberNetPlan",
                newName: "ProviderName");

            migrationBuilder.RenameColumn(
                name: "ProductPrice",
                table: "FiberNetPlan",
                newName: "PlanPrice");

            migrationBuilder.RenameColumn(
                name: "ProductDescription",
                table: "FiberNetPlan",
                newName: "PlanDescription");

            migrationBuilder.RenameColumn(
                name: "Product",
                table: "FiberNetPlan",
                newName: "PlanName");
        }
    }
}

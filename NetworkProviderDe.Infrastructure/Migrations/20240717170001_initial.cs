using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NetArea",
                columns: table => new
                {
                    AreaId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    PlaceName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AdminName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AdminCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    AdminCode2 = table.Column<int>(type: "int", nullable: false),
                    AdminCode3 = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    Accuracy = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetArea", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "NetAreaFiberPlan",
                columns: table => new
                {
                    AreaFiberPlanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaId = table.Column<long>(type: "bigint", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "FiberNetPlan",
                columns: table => new
                {
                    PlanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProviderName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlanName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PlanDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    PlanPrice = table.Column<double>(type: "float", nullable: false),
                    PlanSpeed = table.Column<int>(type: "int", nullable: false),
                    IsUnlimited = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscounted = table.Column<bool>(type: "bit", nullable: false),
                    IsPromoted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NetAreaFiberPlanAreaFiberPlanId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiberNetPlan", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_FiberNetPlan_NetAreaFiberPlan_NetAreaFiberPlanAreaFiberPlanId",
                        column: x => x.NetAreaFiberPlanAreaFiberPlanId,
                        principalTable: "NetAreaFiberPlan",
                        principalColumn: "AreaFiberPlanId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FiberNetPlan_NetAreaFiberPlanAreaFiberPlanId",
                table: "FiberNetPlan",
                column: "NetAreaFiberPlanAreaFiberPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_NetAreaFiberPlan_AreaId",
                table: "NetAreaFiberPlan",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiberNetPlan");

            migrationBuilder.DropTable(
                name: "NetAreaFiberPlan");

            migrationBuilder.DropTable(
                name: "NetArea");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FiberPlanAndRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[FiberNetPlan]([ProviderName],[PlanName],[PlanDescription],[PlanPrice],[PlanSpeed],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[CreatedAt],[UpdatedAt])VALUES('T-Mobile','Fiber300','Fiber 300 Mb/s no limit. Free 3 month',20,300,1,1,0,1,GETDATE(),GETDATE())");
            migrationBuilder.Sql("INSERT INTO [dbo].[FiberNetPlan]([ProviderName],[PlanName],[PlanDescription],[PlanPrice],[PlanSpeed],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[CreatedAt],[UpdatedAt])VALUES('T-Mobile','Fiber600','Fiber up to  600 Mb/s no limit. Free 3 month',35,600,1,1,1,1,GETDATE(),GETDATE())");
            migrationBuilder.Sql("INSERT INTO [dbo].[FiberNetPlan]([ProviderName],[PlanName],[PlanDescription],[PlanPrice],[PlanSpeed],[IsUnlimited],[IsDiscounted],[IsPromoted],[Active],[CreatedAt],[UpdatedAt])VALUES('T-Mobile','Fiber1000','Fiber up to  1 Gb/s no limit. Free 5 month',55,1000,1,1,0,1,GETDATE(),GETDATE())");
            migrationBuilder.Sql("Declare @TmpTbl table (Id bigint IDENTITY(1,1) NOT NULL, id_area bigint ) Declare @IdTempArea bigint insert into @TmpTbl select a.AreaId from NetArea a While exists( select 1 from @TmpTbl) begin select top 1 @IdTempArea = t.id_area from @TmpTbl t INSERT INTO [dbo].[NetAreaFiberPlan]([AreaId],[PlanId]) select @IdTempArea,p.PlanId from FiberNetPlan p delete from @TmpTbl where  id_area = @IdTempArea end ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetworkProviderDe.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserApp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE ROLE netprovider_app AUTHORIZATION db_securityadmin");
            migrationBuilder.Sql("ALTER ROLE db_datareader ADD MEMBER netprovider_app");
            migrationBuilder.Sql("ALTER ROLE db_datawriter ADD MEMBER netprovider_app");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER ROLE db_datawriter DROP MEMBER netprovider_app");
            migrationBuilder.Sql("ALTER ROLE db_datareader DROP MEMBER netprovider_app");
            migrationBuilder.Sql("DROP ROLE netprovider_app");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailServer.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class SetMissedPeriodsToMetering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql($"UPDATE \"Meterings\" SET \"ReportYear\" = EXTRACT(YEAR FROM \"CreateDate\"), \"ReportMonth\" = EXTRACT(MONTH FROM \"CreateDate\") WHERE \"CreateDate\" < NOW()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

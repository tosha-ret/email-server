using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailServer.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class AddPeriodToMetering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SendingDate",
                table: "Meterings",
                newName: "CreateDate");

            migrationBuilder.AddColumn<int>(
                name: "ReportMonth",
                table: "Meterings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportYear",
                table: "Meterings",
                type: "integer",
                nullable: false,
                defaultValue: 0);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportMonth",
                table: "Meterings");

            migrationBuilder.DropColumn(
                name: "ReportYear",
                table: "Meterings");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Meterings",
                newName: "SendingDate");
        }
    }
}

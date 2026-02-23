using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmailServer.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meterings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    SendingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HotWater = table.Column<decimal>(type: "numeric", nullable: false),
                    ColdWater = table.Column<decimal>(type: "numeric", nullable: false),
                    Electricity = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meterings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCompanies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ShortName = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCompanies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ServiceCompanies",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber", "ShortName" },
                values: new object[] { new Guid("c0922377-d913-4533-b32c-8c9ef46a45bc"), "info@ooopek.com", "ООО Первая Эксплуатационная Компания", 89281377770L, "ООО УК ПЭК" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meterings");

            migrationBuilder.DropTable(
                name: "ServiceCompanies");
        }
    }
}

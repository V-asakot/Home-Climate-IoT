using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RoomsClimate.Service.Migrations
{
    /// <inheritdoc />
    public partial class Thermostat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Devices_DeviceGuid",
                table: "Devices",
                column: "DeviceGuid");

            migrationBuilder.CreateTable(
                name: "ThermostatsSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeviceGuid = table.Column<Guid>(type: "uuid", nullable: true),
                    ThermostatName = table.Column<string>(type: "text", nullable: false),
                    ThermostatValue = table.Column<float>(type: "real", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThermostatsSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThermostatsSettings_Devices_DeviceGuid",
                        column: x => x.DeviceGuid,
                        principalTable: "Devices",
                        principalColumn: "DeviceGuid");
                });

            migrationBuilder.InsertData(
                table: "ThermostatsSettings",
                columns: new[] { "Id", "DeviceGuid", "IsActive", "ThermostatName", "ThermostatValue" },
                values: new object[] { 1, null, true, "Default", 24f });

            migrationBuilder.CreateIndex(
                name: "IX_ThermostatsSettings_DeviceGuid",
                table: "ThermostatsSettings",
                column: "DeviceGuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThermostatsSettings");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Devices_DeviceGuid",
                table: "Devices");
        }
    }
}

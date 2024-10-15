using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sentry.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BadgeNumber",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "DeviceSerialNumber",
                table: "Devices",
                newName: "SerialNumber");

            migrationBuilder.RenameColumn(
                name: "ComputerHostName",
                table: "Devices",
                newName: "HostName");

            migrationBuilder.AddColumn<byte>(
                name: "Badge",
                table: "Devices",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Badge",
                table: "Devices");

            migrationBuilder.RenameColumn(
                name: "SerialNumber",
                table: "Devices",
                newName: "DeviceSerialNumber");

            migrationBuilder.RenameColumn(
                name: "HostName",
                table: "Devices",
                newName: "ComputerHostName");

            migrationBuilder.AddColumn<int>(
                name: "BadgeNumber",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

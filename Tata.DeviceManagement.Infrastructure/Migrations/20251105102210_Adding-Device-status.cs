using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tata.DeviceManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddingDevicestatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Devices");
        }
    }
}

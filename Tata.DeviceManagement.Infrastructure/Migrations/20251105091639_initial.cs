using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tata.DeviceManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
<<<<<<<< HEAD:Tata.DeviceManagement.Infrastructure/Migrations/20251105111849_port schema change.cs
    public partial class portschemachange : Migration
========
    public partial class initial : Migration
>>>>>>>> fbd3a78aec7dda830a59ec7ac35311c27ea1d4b2:Tata.DeviceManagement.Infrastructure/Migrations/20251105091639_initial.cs
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaudRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StopBits = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Protocol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConfigurationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceId);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceConfigurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "DeviceConfigurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DevicePorts",
                columns: table => new
                {
<<<<<<<< HEAD:Tata.DeviceManagement.Infrastructure/Migrations/20251105111849_port schema change.cs
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
========
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    DeviceId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
>>>>>>>> fbd3a78aec7dda830a59ec7ac35311c27ea1d4b2:Tata.DeviceManagement.Infrastructure/Migrations/20251105091639_initial.cs
                    PortNumber = table.Column<int>(type: "int", nullable: false),
                    Signal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Register = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortSetVersion = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicePorts_Devices_DeviceId1",
                        column: x => x.DeviceId1,
                        principalTable: "Devices",
                        principalColumn: "DeviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevicePorts_DeviceId1",
                table: "DevicePorts",
                column: "DeviceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ConfigurationId",
                table: "Devices",
                column: "ConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicePorts");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "DeviceConfigurations");
        }
    }
}

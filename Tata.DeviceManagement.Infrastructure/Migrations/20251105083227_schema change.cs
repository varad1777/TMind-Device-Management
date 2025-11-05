using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tata.DeviceManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class schemachange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicePorts_Devices_DeviceId",
                table: "DevicePorts");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceConfigurations_ConfigurationId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_DevicePorts_DeviceId",
                table: "DevicePorts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Devices");

            migrationBuilder.AlterColumn<Guid>(
                name: "DeviceId",
                table: "Devices",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigurationId",
                table: "Devices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId1",
                table: "DevicePorts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "DeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePorts_DeviceId1",
                table: "DevicePorts",
                column: "DeviceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePorts_Devices_DeviceId1",
                table: "DevicePorts",
                column: "DeviceId1",
                principalTable: "Devices",
                principalColumn: "DeviceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceConfigurations_ConfigurationId",
                table: "Devices",
                column: "ConfigurationId",
                principalTable: "DeviceConfigurations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DevicePorts_Devices_DeviceId1",
                table: "DevicePorts");

            migrationBuilder.DropForeignKey(
                name: "FK_Devices_DeviceConfigurations_ConfigurationId",
                table: "Devices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DropIndex(
                name: "IX_DevicePorts_DeviceId1",
                table: "DevicePorts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DeviceId1",
                table: "DevicePorts");

            migrationBuilder.AlterColumn<int>(
                name: "ConfigurationId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "Devices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePorts_DeviceId",
                table: "DevicePorts",
                column: "DeviceId");

            migrationBuilder.AddForeignKey(
                name: "FK_DevicePorts_Devices_DeviceId",
                table: "DevicePorts",
                column: "DeviceId",
                principalTable: "Devices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_DeviceConfigurations_ConfigurationId",
                table: "Devices",
                column: "ConfigurationId",
                principalTable: "DeviceConfigurations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

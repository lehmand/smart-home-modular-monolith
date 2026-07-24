using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartHome.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class RenamedSensorBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SensorBase",
                table: "SensorBase");

            migrationBuilder.RenameTable(
                name: "SensorBase",
                newName: "Sensor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Sensor",
                table: "Sensor");

            migrationBuilder.RenameTable(
                name: "Sensor",
                newName: "SensorBase");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SensorBase",
                table: "SensorBase",
                column: "Id");
        }
    }
}

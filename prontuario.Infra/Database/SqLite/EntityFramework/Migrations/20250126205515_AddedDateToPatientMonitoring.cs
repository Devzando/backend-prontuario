using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedDateToPatientMonitoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MonitoringDate",
                table: "PatientMonitorings",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MonitoringDate",
                table: "PatientMonitorings");
        }
    }
}

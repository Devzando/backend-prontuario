using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPatientMonitoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientMonitorings_MedicalRecords_MedicalRecordId1",
                table: "PatientMonitorings");

            migrationBuilder.DropIndex(
                name: "IX_PatientMonitorings_MedicalRecordId1",
                table: "PatientMonitorings");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId1",
                table: "PatientMonitorings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MedicalRecordId1",
                table: "PatientMonitorings",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PatientMonitorings_MedicalRecordId1",
                table: "PatientMonitorings",
                column: "MedicalRecordId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientMonitorings_MedicalRecords_MedicalRecordId1",
                table: "PatientMonitorings",
                column: "MedicalRecordId1",
                principalTable: "MedicalRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

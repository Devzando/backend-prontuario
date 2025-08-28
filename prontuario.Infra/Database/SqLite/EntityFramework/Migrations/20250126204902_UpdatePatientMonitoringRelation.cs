using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientMonitoringRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientMonitorings_MedicalRecordId",
                table: "PatientMonitorings");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMonitorings_MedicalRecordId",
                table: "PatientMonitorings",
                column: "MedicalRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientMonitorings_MedicalRecordId",
                table: "PatientMonitorings");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMonitorings_MedicalRecordId",
                table: "PatientMonitorings",
                column: "MedicalRecordId",
                unique: true);
        }
    }
}

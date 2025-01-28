using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddPatientMonitoringRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientMonitorings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BloodPressure = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Glucose = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Temperature = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Saturation = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    RespiratoryRate = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    MedicalRecordId = table.Column<long>(type: "INTEGER", nullable: false),
                    MedicalRecordId1 = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMonitorings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientMonitorings_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientMonitorings_MedicalRecords_MedicalRecordId1",
                        column: x => x.MedicalRecordId1,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientMonitorings_MedicalRecordId",
                table: "PatientMonitorings",
                column: "MedicalRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientMonitorings_MedicalRecordId1",
                table: "PatientMonitorings",
                column: "MedicalRecordId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMonitorings");
        }
    }
}

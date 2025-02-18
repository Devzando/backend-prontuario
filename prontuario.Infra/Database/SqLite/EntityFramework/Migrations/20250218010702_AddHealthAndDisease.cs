using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddHealthAndDisease : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthAndDiseaseEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FamilyHAS = table.Column<bool>(type: "INTEGER", nullable: false),
                    FamilyDM = table.Column<bool>(type: "INTEGER", nullable: false),
                    FamilyIAM = table.Column<bool>(type: "INTEGER", nullable: false),
                    FamilyAVC = table.Column<bool>(type: "INTEGER", nullable: false),
                    FamilyAlzheimer = table.Column<bool>(type: "INTEGER", nullable: false),
                    FamilyCA = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnHAS = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnDM = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnIAM = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnAVC = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnAlzheimer = table.Column<bool>(type: "INTEGER", nullable: false),
                    OwnCA = table.Column<bool>(type: "INTEGER", nullable: false),
                    MedicalRecordId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthAndDiseaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthAndDiseaseEntity_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HealthAndDiseaseEntity_MedicalRecordId",
                table: "HealthAndDiseaseEntity",
                column: "MedicalRecordId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HealthAndDiseaseEntity");
        }
    }
}

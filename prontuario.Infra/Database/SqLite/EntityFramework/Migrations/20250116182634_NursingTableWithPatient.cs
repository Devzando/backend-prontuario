using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class NursingTableWithPatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anamneses_Nursing_NursingEntityId",
                table: "Anamneses");

            migrationBuilder.DropForeignKey(
                name: "FK_Nursing_Anamneses_AnamneseId",
                table: "Nursing");

            migrationBuilder.DropIndex(
                name: "IX_Anamneses_NursingEntityId",
                table: "Anamneses");

            migrationBuilder.DropColumn(
                name: "NursingEntityId",
                table: "Anamneses");

            migrationBuilder.RenameColumn(
                name: "AnamneseId",
                table: "Nursing",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Nursing_AnamneseId",
                table: "Nursing",
                newName: "IX_Nursing_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nursing_Patients_PatientId",
                table: "Nursing",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nursing_Patients_PatientId",
                table: "Nursing");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Nursing",
                newName: "AnamneseId");

            migrationBuilder.RenameIndex(
                name: "IX_Nursing_PatientId",
                table: "Nursing",
                newName: "IX_Nursing_AnamneseId");

            migrationBuilder.AddColumn<long>(
                name: "NursingEntityId",
                table: "Anamneses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_NursingEntityId",
                table: "Anamneses",
                column: "NursingEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Anamneses_Nursing_NursingEntityId",
                table: "Anamneses",
                column: "NursingEntityId",
                principalTable: "Nursing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Nursing_Anamneses_AnamneseId",
                table: "Nursing",
                column: "AnamneseId",
                principalTable: "Anamneses",
                principalColumn: "Id");
        }
    }
}

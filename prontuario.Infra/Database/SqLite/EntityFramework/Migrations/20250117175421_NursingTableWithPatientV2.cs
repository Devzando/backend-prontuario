using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class NursingTableWithPatientV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nursing_Patients_PatientId",
                table: "Nursing");

            migrationBuilder.DropIndex(
                name: "IX_Nursing_PatientId",
                table: "Nursing");

            migrationBuilder.AlterColumn<long>(
                name: "PatientId",
                table: "Nursing",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NursingNote",
                table: "Nursing",
                type: "TEXT",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PatientId",
                table: "Nursing",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "NursingNote",
                table: "Nursing",
                type: "TEXT",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_Nursing_PatientId",
                table: "Nursing",
                column: "PatientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Nursing_Patients_PatientId",
                table: "Nursing",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}

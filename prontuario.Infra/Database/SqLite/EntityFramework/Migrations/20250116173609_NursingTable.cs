using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class NursingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "NursingEntityId",
                table: "Anamneses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Nursing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NursingNote = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    AnamneseId = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nursing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nursing_Anamneses_AnamneseId",
                        column: x => x.AnamneseId,
                        principalTable: "Anamneses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_NursingEntityId",
                table: "Anamneses",
                column: "NursingEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Nursing_AnamneseId",
                table: "Nursing",
                column: "AnamneseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anamneses_Nursing_NursingEntityId",
                table: "Anamneses",
                column: "NursingEntityId",
                principalTable: "Nursing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anamneses_Nursing_NursingEntityId",
                table: "Anamneses");

            migrationBuilder.DropTable(
                name: "Nursing");

            migrationBuilder.DropIndex(
                name: "IX_Anamneses_NursingEntityId",
                table: "Anamneses");

            migrationBuilder.DropColumn(
                name: "NursingEntityId",
                table: "Anamneses");
        }
    }
}

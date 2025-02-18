using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicalCare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalCares",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    BreathingPattern_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Bulhas_Value = table.Column<string>(type: "TEXT", nullable: false),
                    ColoracaoPele_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Fala_Value = table.Column<string>(type: "TEXT", nullable: false),
                    NivelDeConsciencia_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Pulmonar_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Pulso_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Pupila_Value = table.Column<string>(type: "TEXT", nullable: false),
                    RespostaMotora_Value = table.Column<string>(type: "TEXT", nullable: false),
                    Ritmo_Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCares_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCares_ServiceId",
                table: "MedicalCares",
                column: "ServiceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalCares");
        }
    }
}

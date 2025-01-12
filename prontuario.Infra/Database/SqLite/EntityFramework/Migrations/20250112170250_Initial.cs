using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prontuario.Infra.Database.SqLite.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    SocialName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    MotherName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Cpf_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Phone_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Rg_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Status_Value = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Sus_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role_Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Number = table.Column<long>(type: "INTEGER", nullable: true),
                    Neighborhood = table.Column<string>(type: "TEXT", maxLength: 40, nullable: true),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false),
                    Cep_Value = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmergencyContactDetails",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false),
                    Phone_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Relationship_Value = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmergencyContactDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmergencyContactDetails_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PatientId = table.Column<long>(type: "INTEGER", nullable: false),
                    ServiceStatus_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    FirstAccess = table.Column<bool>(type: "INTEGER", nullable: false),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProfileId = table.Column<long>(type: "INTEGER", nullable: false),
                    Cpf_Value = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Email_Value = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<long>(type: "INTEGER", nullable: false),
                    Status_Value = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    StatusInCaseOfAdmission_Value = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalRecords_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccessCodes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsUserUpdatePassword = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExperationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessCodes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Anamneses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BloodPressure = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Glucose = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Temperature = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    RespiratoryRate = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    BloodType = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Weight = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    HeartRate = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Saturation = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    Height = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    AntecPathological = table.Column<bool>(type: "INTEGER", nullable: false),
                    NecesPsicobio = table.Column<bool>(type: "INTEGER", nullable: false),
                    Diabetes = table.Column<bool>(type: "INTEGER", nullable: false),
                    MedicationsInUse = table.Column<bool>(type: "INTEGER", nullable: false),
                    UseOfProthesis = table.Column<bool>(type: "INTEGER", nullable: false),
                    Allergies = table.Column<bool>(type: "INTEGER", nullable: false),
                    AllergiesType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    AntecPathologicalType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MedicationInUseType = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MedicalHypothesis = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    PreviousSurgeries = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    MedicalRecordId = table.Column<long>(type: "INTEGER", nullable: false),
                    ClassificationStatus_Value = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anamneses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anamneses_MedicalRecords_MedicalRecordId",
                        column: x => x.MedicalRecordId,
                        principalTable: "MedicalRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessCodes_UserId",
                table: "AccessCodes",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PatientId",
                table: "Addresses",
                column: "PatientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anamneses_MedicalRecordId",
                table: "Anamneses",
                column: "MedicalRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmergencyContactDetails_PatientId",
                table: "EmergencyContactDetails",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_ServiceId",
                table: "MedicalRecords",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_PatientId",
                table: "Services",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileId",
                table: "Users",
                column: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessCodes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Anamneses");

            migrationBuilder.DropTable(
                name: "EmergencyContactDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Address;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.EmergencyContactDetails;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Notes;
using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using prontuario.Domain.Entities.PatientMonitoring;
using prontuario.Domain.Entities.Profile;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Entities.User;

namespace prontuario.Infra.Database
{
    public class ProntuarioDbContext : DbContext
    {
        public DbSet<PatientEntity> Patients { get; private set; }
        public DbSet<AddressEntity> Addresses { get; private set; }
        public DbSet<EmergencyContactDetailsEntity> EmergencyContactDetails { get; private set; }

        public DbSet<ServiceEntity> Services { get; private set; }
        public DbSet<MedicalRecordEntity> MedicalRecords { get; private set; }
        public DbSet<AnamneseEntity> Anamneses { get; private set; }

        public DbSet<UserEntity> Users { get; private set; }
        public DbSet<ProfileEntity> Profiles { get; private set; }
        public DbSet<AccessCodeEntity> AccessCodes { get; private set; }
        public DbSet<NursingEntity> Nursing { get; private set; }
        public DbSet<PatientMonitoringEntity> PatientMonitorings { get; private set; }
        public DbSet<PatientExamsEntity> PatientExams { get; private set; }
        public DbSet<PatientMedicationEntity> PatientMedications { get; private set; }

        public DbSet<NotesEntity> Notes { get; private set; }


        public ProntuarioDbContext(DbContextOptions<ProntuarioDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProntuarioDbContext).Assembly);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Anamnese;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

namespace prontuario.Infra.Database
{
    public class ProntuarioDbContext : DbContext
    {
        public DbSet<PatientModel> Patients { get; private set; }
        public DbSet<AddressModel> Addresses { get; private set; }
        public DbSet<EmergencyContactDetailsModel> EmergencyContactDetails { get; private set; }
        
        public DbSet<ServiceModel> Services { get; private set; }
        public DbSet<MedicalRecordModel> MedicalRecords { get; private set; }
        public DbSet<AnamneseModel> Anamneses { get; private set; }
        
        public DbSet<UserModel> Users { get; private set; }
        public DbSet<ProfileModel> Profiles { get; private set; }
        public DbSet<AccessCodeModel> AccessCodes { get; private set; }
        public ProntuarioDbContext(DbContextOptions<ProntuarioDbContext> options) : base(options)
        {
        }
    }
}

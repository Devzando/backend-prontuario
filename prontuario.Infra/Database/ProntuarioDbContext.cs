using Microsoft.EntityFrameworkCore;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

namespace prontuario.Infra.Database
{
    public class ProntuarioDbContext : DbContext
    {
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<EmergencyContactDetailsModel> EmergencyContactDetails { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }
        public DbSet<AccessCodeModel> AccessCodes { get; set; }
        public ProntuarioDbContext(DbContextOptions<ProntuarioDbContext> options) : base(options)
        {
        }
    }
}

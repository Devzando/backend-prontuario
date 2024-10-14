using Microsoft.EntityFrameworkCore;
using prontuario.Infra.Database.SqLite.EntityFramework.Models;

namespace prontuario.Infra.Database
{
    public class ProntuarioDbContext : DbContext
    {
        public DbSet<PatientModel> Patients { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<EmergencyContactDetailsModel> EmergencyContactDetails { get; set; }
        public DbSet<ServiceModel> Services { get; set; }
        public ProntuarioDbContext(DbContextOptions<ProntuarioDbContext> options) : base(options)
        {
        }
    }
}

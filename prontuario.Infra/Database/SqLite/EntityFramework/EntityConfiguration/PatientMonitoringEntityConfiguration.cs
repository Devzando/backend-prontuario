using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.PatientMonitoring;

namespace prontuario.Infra.Database.SqLite.EntityFramework.EntityConfiguration
{
    public class PatientMonitoringEntityConfiguration : IEntityTypeConfiguration<PatientMonitoringEntity>
    {
        public void Configure(EntityTypeBuilder<PatientMonitoringEntity> builder)
        {
            builder.HasKey(p => p.Id);

            // Configuração de propriedades com tamanho máximo
            builder.Property(p => p.BloodPressure)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Glucose)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Temperature)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.RespiratoryRate)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(p => p.Saturation)
                .HasMaxLength(15)
                .IsRequired();

            // Configuração do relacionamento com MedicalRecord
            builder.HasOne<MedicalRecordEntity>()
                .WithMany(m => m.PatientMonitoring) // assuming a MedicalRecord can have many PatientMonitoringEntities
                .HasForeignKey(p => p.MedicalRecordId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

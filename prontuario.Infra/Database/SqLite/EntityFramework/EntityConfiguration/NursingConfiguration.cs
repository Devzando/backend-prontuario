using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prontuario.Domain.Entities.Nursing;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Infra.Database.SqLite.EntityFramework.EntityConfiguration;

public class NursingConfiguration : IEntityTypeConfiguration<NursingEntity>
{
    public void Configure(EntityTypeBuilder<NursingEntity> builder)
    {
        builder.ToTable("Nursing");

        builder.HasKey(m => m.Id);

        builder.Property(n => n.NursingNote)
            .HasMaxLength(200)
            .IsRequired(false);

        builder.HasOne(n => n.Patient)
            .WithOne(p => p.NursingEntity)
            .HasForeignKey<NursingEntity>(n => n.PatientId) 
            .IsRequired(false);
    }
}
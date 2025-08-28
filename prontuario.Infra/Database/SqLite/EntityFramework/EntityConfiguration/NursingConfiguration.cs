using System.Runtime.CompilerServices;
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
            .IsRequired(true);

        builder.Property(n => n.PatientId)
            .IsRequired(true);
    }
}
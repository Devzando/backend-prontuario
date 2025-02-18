using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prontuario.Domain.Entities.MedicalCare;

namespace prontuario.Infra.Database.SqLite.EntityFramework.EntityConfiguration;

public class MedicalCareConfiguration : IEntityTypeConfiguration<MedicalCareEntity>
{
    public void Configure(EntityTypeBuilder<MedicalCareEntity> builder)
    {
        // Mapeamento da tabela
        builder.ToTable("MedicalCares");

        // Mapeamento da chave primária
        builder.HasKey(mc => mc.Id);
        
        builder.ComplexProperty(mc => mc.BreathingPattern)
            .Property(bp => bp.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.Pulmonar)
            .Property(p => p.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.ColoracaoPele)
            .Property(cp => cp.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.Pupila)
            .Property(p => p.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.Fala)
            .Property(f => f.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.NivelDeConsciencia)
            .Property(nc => nc.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.RespostaMotora)
            .Property(rm => rm.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.Bulhas)
            .Property(b => b.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.Ritmo)
            .Property(r => r.Value)
            .IsRequired();
        
        builder.ComplexProperty(mc => mc.Pulso)
            .Property(p => p.Value)
            .IsRequired();

        builder.HasOne(mc => mc.Service)
            .WithOne(r => r.MedicalCareEntity)
            .OnDelete(DeleteBehavior.Cascade);
    }
}

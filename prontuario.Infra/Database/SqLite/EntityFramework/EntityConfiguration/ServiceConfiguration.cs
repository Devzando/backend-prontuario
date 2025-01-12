using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.EntityConfiguration;

public class ServiceConfiguration : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {
        // Mapeamento da tabela
        builder.ToTable("Services");

        // Mapeamento da chave primária
        builder.HasKey(s => s.Id);

        // Configuração das propriedades
        builder.ComplexProperty(s => s.ServiceStatus)
            .Property(s => s.Value)
            .HasMaxLength(15)
            .IsRequired(false); // Pode ser nulo, conforme o modelo

        builder.Property(s => s.ServiceDate)
            .IsRequired(); // Data obrigatória

        // Configuração da chave estrangeira com Patient
        builder.HasOne(s => s.PatientEntity) // Relacionamento com Patient
            .WithMany(s => s.ServicesEntity) // Caso o modelo Patient tenha um relacionamento reverso
            .HasForeignKey(s => s.PatientId)
            .OnDelete(DeleteBehavior.Cascade); // Cascata para deletar o serviço se o paciente for excluído

        // Configuração da chave estrangeira com MedicalRecord
        builder.HasOne(s => s.MedicalRecordEntity) // Relacionamento com MedicalRecord
            .WithOne(s => s.Service) // Caso o modelo MedicalRecord tenha um relacionamento reverso
            .IsRequired(false); // Opcional, pois o MedicalRecord pode ser nulo
    }
}
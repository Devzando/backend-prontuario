using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.PatientMonitoring;
using prontuario.Domain.Entities.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.EntityConfiguration;

public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecordEntity>
{
    public void Configure(EntityTypeBuilder<MedicalRecordEntity> builder)
    {
        // Mapeamento da tabela
        builder.ToTable("MedicalRecords");

        // Mapeamento da chave primária
        builder.HasKey(m => m.Id);

        // Configuração das propriedades
        builder.ComplexProperty(m => m.Status)
            .Property(m => m.Value)
            .HasMaxLength(20)
            .IsRequired();

        builder.ComplexProperty(m => m.StatusInCaseOfAdmission)
            .Property(m => m.Value)
            .HasMaxLength(20)
            .IsRequired(false); // Opcional

        // Configuração da chave estrangeira com Service
        builder.HasOne<ServiceEntity>() // Relacionamento com ServiceEntity
            .WithOne(m => m.MedicalRecordEntity) // Caso o modelo ServiceEntity tenha um relacionamento reverso
            .HasForeignKey<MedicalRecordEntity>(m => m.ServiceId)
            .OnDelete(DeleteBehavior.Cascade); // Cascata para deletar o prontuário se o serviço for excluído

        // Configuração da chave estrangeira com Anamnese
        builder.HasOne(m => m.Anamnese) // Relacionamento com AnamneseEntity
            .WithOne(m => m.MedicalRecord) // Caso o modelo AnamneseEntity tenha um relacionamento reverso
            .IsRequired(false); // Opcional, pois a Anamnese pode ser nula

        // Configuração da chave estrangeira com PatientMonitoring
        builder.HasMany(m => m.PatientMonitoring) // Relacionamento 1:N
            .WithOne(p => p.MedicalRecord) // Cada PatientMonitoring está associado a um único MedicalRecord
            .HasForeignKey(p => p.MedicalRecordId) // Define a chave estrangeira
            .OnDelete(DeleteBehavior.Cascade); // Cascata para deletar os monitoramentos se o prontuário for excluído

        // Configuração do relacionamento com PatientExams
        builder.HasMany(mr => mr.PatientExams)  // Um MedicalRecord pode ter muitos PatientExams
            .WithOne(pe => pe.MedicalRecord)    // Cada PatientExam pertence a um MedicalRecord
            .HasForeignKey(pe => pe.MedicalRecordId)
            .OnDelete(DeleteBehavior.Cascade);  // Cascade delete para manter a integridade dos dados
    }
}
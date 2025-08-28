using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.User;

namespace prontuario.Infra.Database.SqLite.EntityFramework.EntityConfiguration;

public class AccessCodeConfiguration : IEntityTypeConfiguration<AccessCodeEntity>
{
    public void Configure(EntityTypeBuilder<AccessCodeEntity> builder)
    {
        // Configuração da chave primária
        builder.HasKey(a => a.Id);

        // Configuração da propriedade Code (campo obrigatório)
        builder.Property(a => a.Code)
            .IsRequired()  // A propriedade Code é obrigatória
            .HasMaxLength(50);  // Definindo um tamanho máximo para o código

        // Configuração da propriedade IsActive (valor padrão: true)
        builder.Property(a => a.IsActive)
            .IsRequired();  // A propriedade IsActive é obrigatória

        // Configuração da propriedade IsUserUpdatePassword (valor padrão: false)
        builder.Property(a => a.IsUserUpdatePassword)
            .IsRequired();  // A propriedade IsUserUpdatePassword é obrigatória

        // Configuração da propriedade ExperationDate (campo obrigatório)
        builder.Property(a => a.ExperationDate)
            .IsRequired();  // A propriedade ExperationDate é obrigatória

        builder.HasOne<UserEntity>() // Exemplo de relacionamento com uma entidade User
           .WithOne(u => u.AccessCode) // Relacionamento 1:1
           .HasForeignKey<AccessCodeEntity>(u => u.UserId) // Chave estrangeira
           .OnDelete(DeleteBehavior.Cascade); // Comportamento de exclusão em cascata
    }
}
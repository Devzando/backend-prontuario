using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

[Table("Users")]
public class UserModel(
    long? id,
    string name,
    string email,
    string cpf,
    string password,
    ProfileModel profile,
    AccessCodeModel accessCode)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; } = id;

    [Required]
    [MaxLength(150)]
    public string Name { get; private set; } = name;

    [Required]
    [MaxLength(200)]
    public string Email { get; private set; } = email;

    [Required]
    [MaxLength(15)]
    public string Cpf { get; private set; } = cpf;

    [Required]
    public string Password { get; private set; } = password;

    [Required]
    public long ProfileId { get; private set; }

    [ForeignKey("ProfileId")]
    [Column("Profile_Id")]
    public ProfileModel Profile { get; private set; } = profile;

    public AccessCodeModel AccessCode { get; private set; } = accessCode;
}
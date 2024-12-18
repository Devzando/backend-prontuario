using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

[Table("Users")]
public class UserModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; private set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Email { get; private set; } = string.Empty;

    [Required]
    [MaxLength(15)]
    public string Cpf { get; private set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Password { get; private set; } = string.Empty;
    
    [Required]
    public bool FirstAccess { get; private set; } = false;

    [Required]
    public bool Active { get; private set; } = false;
    
    [Required]
    public long ProfileId { get; private set; }

    [ForeignKey("ProfileId")]
    [Column("Profile_Id")]
    public ProfileModel Profile { get; private set; } = null!;

    public AccessCodeModel AccessCode { get; private set; } = null!;
    
    public UserModel() { }

    public UserModel(long? id, string name, string email, string cpf, string password, bool firstAccess, bool active, ProfileModel profile,
        AccessCodeModel accessCode)
    {
        Id = id;
        Name = name;
        Email = email;
        Cpf = cpf;
        Password = password;
        FirstAccess = firstAccess;
        Active = active;
        Profile = profile;
        AccessCode = accessCode;
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

[Table("Profiles")]
public class ProfileModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; set; }

    [Required]
    [MaxLength(20)]
    public string Role { get; set; } = string.Empty;

    public ICollection<ProfileContainsPermissionModel> ProfileContainsPermission { get; set; } = null!;
    
    public ProfileModel() {}

    public ProfileModel(long? id, string role, ICollection<ProfileContainsPermissionModel> profileContainsPermission)
    {
        Id = id;
        Role = role;
        ProfileContainsPermission = profileContainsPermission;
    }
}
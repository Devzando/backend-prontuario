using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

[Table("Profiles")]
public class ProfileModel(long? id, string role, ICollection<ProfileContainsPermissionModel> profileContainsPermission)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; } = id;

    [Required]
    [MaxLength(20)]
    public string Role { get; private set; } = role;

    public ICollection<ProfileContainsPermissionModel> ProfileContainsPermission { get; private set; } = profileContainsPermission;
}
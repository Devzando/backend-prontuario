using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Permission;

[Table("Permissions")]
public class PermissionModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; }

    [Required]
    [MaxLength(150)]
    public string Title { get; private set; } = string.Empty;

    public ICollection<ProfileContainsPermissionModel> ProfileContainsPermission { get; private set; } = null!;
    public PermissionModel() {}
    public PermissionModel(long? id, string title,
        ICollection<ProfileContainsPermissionModel> profileContainsPermission)
    {
        Id = id;
        Title = title;
        ProfileContainsPermission = profileContainsPermission;
    }
}
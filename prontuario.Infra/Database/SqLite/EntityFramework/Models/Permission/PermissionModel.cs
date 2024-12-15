using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Permission;

[Table("Permissions")]
public class PermissionModel(long? id, string title, ICollection<ProfileContainsPermissionModel> profileContainsPermission)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; } = id;

    [Required]
    [MaxLength(150)]
    public string Title { get; set; } = title;

    public ICollection<ProfileContainsPermissionModel> ProfileContainsPermission { get; private set; } = profileContainsPermission;
}
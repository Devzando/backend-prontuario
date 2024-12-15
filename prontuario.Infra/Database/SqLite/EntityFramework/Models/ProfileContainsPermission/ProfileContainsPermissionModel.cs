using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Permission;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

[Table("Profile_Contains_Permissions")]
public class ProfileContainsPermissionModel(long? id, ProfileModel profile, PermissionModel permission)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; } = id;

    [Required]
    public long ProfileId { get; private set; }
    
    [ForeignKey("ProfileId")]
    [Column("Profile_Id")]
    public ProfileModel Profile { get; private set; } = profile;

    [Required]
    public long PermissionId { get; private set; }
    
    [ForeignKey("PermissionId")]
    [Column("Permission_Id")]
    public PermissionModel Permission { get; private set; } = permission;
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Permission;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Profile;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.ProfileContainsPermission;

[Table("Profile_Contains_Permissions")]
public class ProfileContainsPermissionModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; }

    [Required]
    public long ProfileId { get; private set; }
    
    [ForeignKey("ProfileId")]
    [Column("Profile_Id")]
    public ProfileModel Profile { get; private set; } = null!;

    [Required]
    public long PermissionId { get; private set; }
    
    [ForeignKey("PermissionId")]
    [Column("Permission_Id")]
    public PermissionModel Permission { get; private set; } = null!;
    
    public ProfileContainsPermissionModel() {}

    public ProfileContainsPermissionModel(long? id, ProfileModel profile, PermissionModel permission)
    {
        Id = id;
        Profile = profile;
        Permission = permission;
    }
}
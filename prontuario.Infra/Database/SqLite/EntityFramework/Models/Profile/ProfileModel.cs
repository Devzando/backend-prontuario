using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    
    public ProfileModel() {}

    public ProfileModel(long? id, string role)
    {
        Id = id;
        Role = role;
    }
}
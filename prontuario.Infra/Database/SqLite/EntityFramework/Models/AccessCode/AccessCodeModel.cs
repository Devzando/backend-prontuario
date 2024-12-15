using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;

[Table("AccessCodes")]
public class AccessCodeModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; }

    [Required]
    [MaxLength(100)]
    public string Code { get; private set; } = string.Empty;

    [Required] 
    public bool IsActive { get; private set; }

    [Required]
    public bool IsUserUpdatePassword { get; private set; }

    [Required]
    public DateTime ExperationDate { get; private set; }

    [Required]
    public long UserId { get; private set; }
    
    [ForeignKey("UserId")]
    [Column("User_Id")]
    public UserModel User { get; private set; } = null!;
    public AccessCodeModel() { }

    public AccessCodeModel(long? id, string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
    {
        Id = id;
        Code = code;
        IsActive = isActive;
        IsUserUpdatePassword = isUserUpdatePassword;
        ExperationDate = experationDate;
    }
}
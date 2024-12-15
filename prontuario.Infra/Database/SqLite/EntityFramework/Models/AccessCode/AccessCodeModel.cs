using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.AccessCode;

[Table("AccessCodes")]
public class AccessCodeModel(long? id, string code, bool isActive, bool isUserUpdatePassword, DateTime experationDate)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; } = id;

    [Required]
    public string Code { get; private set; } = code;

    [Required] 
    public bool IsActive { get; private set; } = isActive;

    [Required]
    public bool IsUserUpdatePassword { get; private set; } = isUserUpdatePassword;

    [Required]
    public DateTime ExperationDate { get; private set; } = experationDate;

    [Required]
    public long UserId { get; private set; }
    
    [ForeignKey("UserId")]
    [Column("User_Id")]
    public UserModel User { get; private set; } = null!;
}
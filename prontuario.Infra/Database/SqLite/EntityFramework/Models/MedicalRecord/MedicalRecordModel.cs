using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Anamnese;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;

[Table("MedicalRecords")]
public class MedicalRecordModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; }
    
    [Required]
    [MaxLength(20)]
    public string Status { get; private set; } = string.Empty;

    [MaxLength(20)]
    public string? StatusInCaseOfAdmission { get; private set; }

    [Required]
    public long ServiceId { get; private set; }
    
    [ForeignKey("ServiceId")]
    [Column("Service_Id")]
    public ServiceModel Service { get; private set; } = null!;
    public AnamneseModel Anamnese { get; private set; } = null!;
    
    public MedicalRecordModel() { }

    public MedicalRecordModel(long? id, string status, string? statusInCaseOfAdmission, AnamneseModel anamnese)
    {
        Id = id;
        Status = status;
        StatusInCaseOfAdmission = statusInCaseOfAdmission;
        Anamnese = anamnese;
    }
}
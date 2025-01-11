using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Anamnese;

[Table("Anamneses")]
public class AnamneseModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long? Id { get; private set; }
    
    [Required]
    [MaxLength(15)]
    public string BloodPressure { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string Glucose { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string Temperature { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string RespiratoryRate { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string BloodType { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string Weight { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string HeartRate { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string Saturation { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(15)]
    public string Height { get; private set; } = string.Empty;
    
    [Required]
    public bool AntecPathological { get; private set; } = false;
    
    [Required]
    public bool NecesPsicobio { get; private set; } = false;
    
    [Required]
    public bool Diabetes { get; private set; } = false;
    
    [Required]
    public bool MedicationsInUse { get; private set; } = false;
    
    [Required]
    public bool UseOfProthesis { get; private set; } = false;
    
    [Required]
    public bool Allergies { get; private set; } = false;
    
    [Required]
    [MaxLength(100)]
    public string AllergiesType { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string AntecPathologicalType { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string MedicationInUseType { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string MedicalHypothesis { get; private set; } = string.Empty;
    
    [Required]
    [MaxLength(100)]
    public string PreviousSurgeries { get; private set; } = string.Empty;

    [Required] 
    public string ClassificationStatus { get; private set; } = string.Empty;
    
    [Required]
    public long MedicalRecordId { get; private set; }
        
    [ForeignKey("MedicalRecordId")]
    [Column("Medical_Record_Id")]
    public MedicalRecordModel MedicalRecordModel { get; private set; } = null!;
    
    public AnamneseModel() { }

    public AnamneseModel(
        long? id,
        string bloodPressure,
        string glucose,
        string temperature,
        string respiratoryRate,
        string bloodType,
        string weight,
        string heartRate,
        string saturation,
        string height,
        bool antecPathological,
        bool necesPsicobio,
        bool diabetes,
        bool medicationsInUse,
        bool useOfProthesis,
        bool allergies,
        string allergiesType,
        string antecPathologicalType,
        string medicationInUseType,
        string medicalHypothesis,
        string previousSurgeries,
        string classificationStatus
        )
    {
        Id = id;
        BloodPressure = bloodPressure;
        Glucose = glucose;
        Temperature = temperature;
        RespiratoryRate = respiratoryRate;
        BloodType = bloodType;
        Weight = weight;
        HeartRate = heartRate;
        Saturation = saturation;
        Height = height;
        AntecPathological = antecPathological;
        NecesPsicobio = necesPsicobio;
        Diabetes = diabetes;
        MedicationsInUse = medicationsInUse;
        UseOfProthesis = useOfProthesis;
        Allergies = allergies;
        AllergiesType = allergiesType;
        AntecPathologicalType = antecPathologicalType;
        MedicationInUseType = medicationInUseType;
        MedicalHypothesis = medicalHypothesis;
        PreviousSurgeries = previousSurgeries;
        ClassificationStatus = classificationStatus;
    }
}
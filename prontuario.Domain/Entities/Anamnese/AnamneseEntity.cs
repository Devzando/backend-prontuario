namespace prontuario.Domain.Entities.Anamnese;

public class AnamneseEntity
{
    public long? Id { get; private set; }
    public string BloodPressure { get; private set; } = string.Empty;
    public string Glucose { get; private set; } = string.Empty;
    public string Temperature { get; private set; } = string.Empty;
    public string RespiratoryRate { get; private set; } = string.Empty;
    public string BloodType { get; private set; } = string.Empty;
    public string Weight { get; private set; } = string.Empty;
    public string HeartRate { get; private set; } = string.Empty;
    public string Saturation { get; private set; } = string.Empty;
    public string Height { get; private set; } = string.Empty;
    public bool AntecPathological { get; private set; } = false;
    public bool NecesPsicobio { get; private set; } = false;
    public bool Diabetes { get; private set; } = false;
    public bool MedicationsInUse { get; private set; } = false;
    public bool UseOfProthesis { get; private set; } = false;
    public bool Allergies { get; private set; } = false;
    public string AllergiesType { get; private set; } = string.Empty;
    public string AntecPathologicalType { get; private set; } = string.Empty;
    public string MedicationInUseType { get; private set; } = string.Empty;
    public string MedicalHypothesis { get; private set; } = string.Empty;
    public string PreviousSurgeries { get; private set; } = string.Empty;
    public bool ClassificationStatus { get; private set; } = false;
    
    public AnamneseEntity() { }
    
    public AnamneseEntity(
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
        bool classificationStatus)
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
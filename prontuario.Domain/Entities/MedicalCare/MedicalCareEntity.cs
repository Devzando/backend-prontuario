using prontuario.Domain.Entities.Patient;

namespace prontuario.Domain.Entities.MedicalCare;

public class MedicalCareEntity
{
    public long Id { get; private set; }
    public string? ExamPrescription { get; private set; }
    public string? MedicalHypothesis { get; private set; }
    public string? MedicalPrescription { get; private set; }
    public long PatientId { get; private set; }
    public MedicalCareEntity() { }
    
    public MedicalCareEntity(long id, string? examPrescription, string? medicalHypothesis, string? medicalPrescription, long patient)
    {
        this.Id = id;
        this.ExamPrescription = examPrescription;
        this.MedicalHypothesis = medicalHypothesis;
        this.MedicalPrescription = medicalPrescription;
        this.PatientId = patient;
    }
}
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;
using prontuario.Domain.Entities.PatientMonitoring;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using prontuario.Domain.Entities.HealthAndDisease;

namespace prontuario.Domain.Entities.MedicalRecord;

public class MedicalRecordEntity
{
    public long Id { get; private set; }
    public MedicalRecordStatus Status { get; set; } = null!;
    public MedicalRecordStatus StatusInCaseOfAdmission { get; private set; }
    public AnamneseEntity? Anamnese { get; set; }
    public ICollection<PatientMonitoringEntity> PatientMonitoring { get; set; } = new List<PatientMonitoringEntity>();
    public ICollection<PatientExamsEntity> PatientExams { get; set; } = new List<PatientExamsEntity>();
    public ICollection<PatientMedicationEntity> PatientMedications { get; set; } = new List<PatientMedicationEntity>();
    public HealthAndDiseaseEntity HealthAndDisease { get; private set; } = null!;
    public long ServiceId { get; private set; }
    public ServiceEntity Service { get; private set; } = null!;
    
    public MedicalRecordEntity() { }

    public MedicalRecordEntity(long id, MedicalRecordStatus status, MedicalRecordStatus statusInCaseOfAdmission, AnamneseEntity? anamnese)
    {
        this.Id = id;
        this.Status = status;
        this.StatusInCaseOfAdmission = statusInCaseOfAdmission;
        this.Anamnese = anamnese;
    }
    public void SetHealthAndDisease(HealthAndDiseaseEntity healthAndDisease)
    {
        HealthAndDisease = healthAndDisease;
    }
}
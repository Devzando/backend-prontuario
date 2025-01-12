using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.MedicalRecord;

public class MedicalRecordEntity
{
    public long Id { get; private set; }
    public MedicalRecordStatus Status { get; set; } = null!;
    public MedicalRecordStatus StatusInCaseOfAdmission { get; private set; }
    public AnamneseEntity? Anamnese { get; set; }
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
}
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.MedicalRecord;

public class MedicalRecordEntity
{
    public long? Id { get; private set; }
    public MedicalRecordStatus Status { get; private set; }
    public MedicalRecordStatus? StatusInCaseOfAdmission { get; private set; }
    public AnamneseEntity Anamnese { get; private set; }
    
    public MedicalRecordEntity() { }

    public MedicalRecordEntity(long? id, MedicalRecordStatus status, MedicalRecordStatus? statusInCaseOfAdmission, AnamneseEntity anamnese)
    {
        this.Id = id;
        this.Status = status;
        this.StatusInCaseOfAdmission = statusInCaseOfAdmission;
        this.Anamnese = anamnese;
    }
}
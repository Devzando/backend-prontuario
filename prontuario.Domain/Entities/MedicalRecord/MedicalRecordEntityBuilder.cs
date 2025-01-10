using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.MedicalRecord;

public class MedicalRecordEntityBuilder
{
    private long? _id;
    private MedicalRecordStatus _status;
    private MedicalRecordStatus? _statusInCaseOfAdmission;
    private AnamneseEntity _anamnese = null!;

    public MedicalRecordEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public MedicalRecordEntityBuilder WithStatus(MedicalRecordStatus status)
    {
        _status = status;
        return this;
    }

    public MedicalRecordEntityBuilder WithStatusInCaseOfAdmission(MedicalRecordStatus statusInCaseOfAdmission)
    {
        _statusInCaseOfAdmission = statusInCaseOfAdmission;
        return this;
    }
    
    public MedicalRecordEntityBuilder WithAnamnese(AnamneseEntity anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public MedicalRecordEntity Build()
    {
        return new MedicalRecordEntity(_id, _status, _statusInCaseOfAdmission, _anamnese);
    }
}
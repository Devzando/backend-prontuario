using prontuario.Infra.Database.SqLite.EntityFramework.Models.Anamnese;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;

public class MedicalRecordModelBuilder
{
    private long? _id;
    private string _status = string.Empty;
    private string? _statusInCaseOfAdmission;
    private AnamneseModel _anamnese = null!;

    public MedicalRecordModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public MedicalRecordModelBuilder WithStatus(string status)
    {
        _status = status;
        return this;
    }

    public MedicalRecordModelBuilder WithStatusInCaseOfAdmission(string? statusInCaseOfAdmission)
    {
        _statusInCaseOfAdmission = statusInCaseOfAdmission;
        return this;
    }

    public MedicalRecordModelBuilder WithAnamnese(AnamneseModel anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public MedicalRecordModel Build()
    {
        return new MedicalRecordModel(_id, _status, _statusInCaseOfAdmission, _anamnese);
    }
}
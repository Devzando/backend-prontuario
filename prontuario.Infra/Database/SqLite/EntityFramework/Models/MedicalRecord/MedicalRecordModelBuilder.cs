using prontuario.Infra.Database.SqLite.EntityFramework.Models.Anamnese;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Service;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;

public class MedicalRecordModelBuilder
{
    private long? _id;
    private AnamneseModel _anamnese = null!;

    public MedicalRecordModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public MedicalRecordModelBuilder WithAnamnese(AnamneseModel anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public MedicalRecordModel Build()
    {
        return new MedicalRecordModel(_id, _anamnese);
    }
}
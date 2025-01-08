using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;

namespace prontuario.Domain.Entities.MedicalRecord;

public class MedicalRecordEntityBuilder
{
    private long? _id;
    private AnamneseEntity _anamnese = null!;

    public MedicalRecordEntityBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public MedicalRecordEntityBuilder WithAnamnese(AnamneseEntity anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public MedicalRecordEntity Build()
    {
        return new MedicalRecordEntity(_id, _anamnese);
    }
}
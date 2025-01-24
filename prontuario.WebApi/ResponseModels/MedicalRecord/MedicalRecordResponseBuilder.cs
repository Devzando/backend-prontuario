using prontuario.WebApi.ResponseModels.Anamnese;

namespace prontuario.WebApi.ResponseModels.MedicalRecord;

public class MedicalRecordResponseBuilder
{
    private long _id;
    private string? _status;
    private AnamneseResponse? _anamnese;

    public MedicalRecordResponseBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public MedicalRecordResponseBuilder WithStatus(string? status)
    {
        _status = status;
        return this;
    }

    public MedicalRecordResponseBuilder WithAnamnese(AnamneseResponse? anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public MedicalRecordResponse Build()
    {
        return new MedicalRecordResponse(
            _id,
            _status,
            _anamnese
        );
    }
}
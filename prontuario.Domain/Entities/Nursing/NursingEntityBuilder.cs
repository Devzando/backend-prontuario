using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Domain.Entities.Nursing;

public class NursingEntityBuilder
{
    private long _id;
    private string? _nursingNote;
    private long _patientId;

    public NursingEntityBuilder WithId(long id){
        _id = id;
        return this;
    }

    public NursingEntityBuilder WithNursingNote(string? nursingNote) 
    {
        _nursingNote = nursingNote;
        return this;
    }

    public NursingEntityBuilder WithPatientId(long patientId)
    {
        _patientId = patientId;
        return this;
    }

    public NursingEntity Build() 
    {
        return new NursingEntity(_id, _nursingNote, _patientId);
    }
}
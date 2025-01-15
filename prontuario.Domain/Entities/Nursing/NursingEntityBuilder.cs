using prontuario.Domain.Entities.Anamnese;

namespace prontuario.Domain.Entities.Nursing;

public class NursingEntityBuilder
{
    private long _id;
    private string? _nursingNote;
    private AnamneseEntity? _anamnese;

    public NursingEntityBuilder WithId(long id){
        _id = id;
        return this;
    }

    public NursingEntityBuilder WithNursingNote(string? nursingNote) 
    {
        _nursingNote = nursingNote;
        return this;
    }

    public NursingEntityBuilder WithAnamnese(AnamneseEntity? anamnese)
    {
        _anamnese = anamnese;
        return this;
    }

    public NursingEntity Build() 
    {
        return new NursingEntity(_id, _nursingNote, _anamnese);
    }
}
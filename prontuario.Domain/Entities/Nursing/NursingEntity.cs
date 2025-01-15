using prontuario.Domain.Entities.Anamnese;

namespace prontuario.Domain.Entities.Nursing;

public class NursingEntity
{
    public long Id { get; private set; }
    public string? NursingNote { get; private set; }
    public AnamneseEntity? Anamnese { get; set; }
    public NursingEntity() { }
    
    public NursingEntity(long id, string? nursingNote, AnamneseEntity? anamnese)
    {
        this.Id = id;
        this.NursingNote = nursingNote;
        this.Anamnese = anamnese;
    }
}
using prontuario.Domain.Entities.Patient;

namespace prontuario.Domain.Entities.Nursing;

public class NursingEntity
{
    public long Id { get; private set; }
    public string? NursingNote { get; private set; }
    public long PatientId { get; private set; }
    public NursingEntity() { }
    
    public NursingEntity(long id, string? nursingNote, long patient)
    {
        this.Id = id;
        this.NursingNote = nursingNote;
        this.PatientId = patient;
    }
}
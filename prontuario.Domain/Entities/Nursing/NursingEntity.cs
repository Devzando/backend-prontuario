using prontuario.Domain.Entities.Patient;

namespace prontuario.Domain.Entities.Nursing;

public class NursingEntity
{
    public long Id { get; private set; }
    public string? NursingNote { get; private set; }
    public PatientEntity? Patient { get;  set; }
    public long? PatientId { get; private set; }
    public NursingEntity() { }
    
    public NursingEntity(long id, string? nursingNote, PatientEntity? patient)
    {
        this.Id = id;
        this.NursingNote = nursingNote;
        this.Patient = patient;
        this.PatientId = patient?.Id;
    }
}
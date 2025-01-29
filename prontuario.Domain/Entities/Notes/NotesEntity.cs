
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.User;

namespace prontuario.Domain.Entities.Notes;

public class NotesEntity
{
    public long Id { get; private set; }
    public string Description { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public long PatientId { get; private set; }
    public long UserId { get; private set; }
    public PatientEntity Patient { get; private set; }
    public UserEntity User { get; private set; }
    public NotesEntity() { }
    public NotesEntity(long id, string description, DateTime createdAt, PatientEntity patient, UserEntity user)
    {
        this.Id = id;
        this.Description = description;
        this.CreatedAt = createdAt;
        this.Patient = patient;
        this.User = user;
    }
}

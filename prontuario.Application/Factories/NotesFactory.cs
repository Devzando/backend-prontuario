
using prontuario.Domain.Entities.Notes;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.User;

namespace prontuario.Application.Factories;

public class NotesFactory
{
    public static NotesEntity CreateNotes(string description, PatientEntity patient, UserEntity user)
    {
        return new NotesEntityBuilder()
            .WithDescription(description)
            .WithCreatedAt(DateTime.Now)
            .WithPatient(patient)
            .WithUser(user)
            .Build();
    }
}

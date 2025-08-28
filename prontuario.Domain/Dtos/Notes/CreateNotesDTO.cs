namespace prontuario.Domain.Dtos.Notes;

public record CreateNotesDTO(
    string Description,
    long PatientId,
    long UserId
);

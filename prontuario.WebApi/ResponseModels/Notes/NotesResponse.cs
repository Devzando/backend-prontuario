namespace prontuario.WebApi.ResponseModels.Notes;

public record NotesResponse(
    long Id,
    string NameUser,
    string PositionUser,
    string Description,
    DateTime CreatedAt);

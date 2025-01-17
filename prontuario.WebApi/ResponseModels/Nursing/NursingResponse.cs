namespace prontuario.WebApi.ResponseModels.Nursing;

public record NursingResponse(
    long Id, 
    string? NursingNote, 
    long PatiendId);
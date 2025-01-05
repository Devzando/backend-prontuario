namespace prontuario.WebApi.RequestModels.User;

public record UpdateUserPasswordRequest(
    string Email,
    string Password,
    string AccessCode
    );
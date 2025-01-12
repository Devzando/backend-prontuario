namespace prontuario.WebApi.ResponseModels.User;

public record UserResponse(
    long? Id,
    string Name,
    string Email,
    string Cpf,
    ProfileResponse Profile,
    string AccessCode
    );
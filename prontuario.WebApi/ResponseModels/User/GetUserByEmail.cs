namespace prontuario.WebApi.ResponseModels;

public record GetUserByEmail(
    long? Id,
    string Name,
    string Email,
    string Cpf,
    ProfileResponse Profile,
    string AccessCode
    )
{
}
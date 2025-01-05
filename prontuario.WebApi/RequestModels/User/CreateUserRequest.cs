namespace prontuario.WebApi.RequestModels.User
{
    public record CreateUserRequest(
        string Name,
        string Email,
        string Cpf,
        ProfileRequest Profile)
    {
    }
}

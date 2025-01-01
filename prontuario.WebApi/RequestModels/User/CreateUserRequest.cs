namespace prontuario.WebApi.RequestModels.User
{
    public record CreateUserRequest(
        string Name,
        string Email,
        string Cpf,
        string Password,
        bool FirstAccess,
        bool Active,
        ProfileRequest Profile)
    {
    }
}

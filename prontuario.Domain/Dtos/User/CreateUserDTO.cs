namespace prontuario.Domain.Dtos.User
{
    public record CreateUserDTO(
        string Name,
        string Email,
        string Cpf,
        string Password,
        bool FirstAccess,
        bool Active,
        ProfileDTO Profile,
        AccessCodeDTO AccessCode
        )
    {
    }
}

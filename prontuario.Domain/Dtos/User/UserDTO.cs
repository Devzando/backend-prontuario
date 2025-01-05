namespace prontuario.Domain.Dtos.User
{
    public record UserDTO(
        long? Id,
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

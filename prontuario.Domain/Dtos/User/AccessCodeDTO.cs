namespace prontuario.Domain.Dtos.User
{
    public record AccessCodeDTO(string Code, bool IsActive, bool IsUserUpdatePassword, DateTime ExperationDate)
    {
    }
}

namespace prontuario.Domain.Dtos.User
{
    public record AccessCodeDTO(long? Id, string Code, bool IsActive, bool IsUserUpdatePassword, DateTime ExperationDate)
    {
    }
}

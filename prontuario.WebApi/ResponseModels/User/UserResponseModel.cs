using prontuario.Domain.Entities.User;
using prontuario.Domain.ValuesObjects;

namespace prontuario.WebApi.ResponseModels
{
    public class UserResponseModel
    {
        public static GetUserByEmail CreateGetUserByEmail(UserEntity user)
        {
            return new GetUserByEmail(
                user.Id,
                user.Name,
                user.Email.Value,
                user.Cpf.Value,
                new ProfileResponse(
                    user.Profile.Role
                ),
                user.AccessCode.Code
                );
        }
    }
}

using prontuario.Domain.Dtos.User;
using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Profile;
using prontuario.Domain.Entities.User;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories
{
    public class UserFactory
    {
        public static UserEntity CreateUser(CreateUserDTO data, string hashedPassword)
        {
            return new UserEntity(
                data.Name,
                new Email(data.Email),
                new CPF(data.Cpf),
                hashedPassword,
                data.FirstAccess,
                data.Active,
                new ProfileEntity(new Role(data.Profile.Role)),
                new AccessCodeEntity(
                    data.AccessCode.Code,
                    data.AccessCode.IsActive,
                    data.AccessCode.IsUserUpdatePassword,
                    data.AccessCode.ExperationDate
                )
            );
        }
    }
}

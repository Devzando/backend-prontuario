using prontuario.Domain.Dtos.User;
using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Profile;
using prontuario.Domain.Entities.User;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories
{
    public class UserFactory
    {
        public static UserEntity CreateUser(CreateUserDTO data, AccessCodeEntity accessCode)
        {
            var genericPassword = $"{data.Email}_{data.Cpf}";
            return new UserEntityBuilder()
                .WithName(data.Name)
                .WithEmail(new Email(data.Email))
                .WithCpf(new CPF(data.Cpf))
                .WithPassword(genericPassword)
                .WithActive(true)
                .WithFirstAccess(false)
                .WithProfile(new ProfileEntityBuilder()
                    .WithRoleType(new Role(data.Profile.Role))
                    .Build())
                .WithAccessCode(new AccessCodeEntityBuilder()
                    .WithCode(accessCode.Code)
                    .WithIsActive(accessCode.IsActive)
                    .WithIsUserUpdatePassword(accessCode.IsUserUpdatePassword)
                    .WithExperimentDate(accessCode.ExperationDate)
                    .Build())
                .Build();
        }

        public static UserEntity CreateUser(UserEntity user, string password, bool firstAccess)
        {
            return new UserEntityBuilder()
                .WithName(user.Name)
                .WithEmail(new Email(user.Email.Value))
                .WithCpf(new CPF(user.Cpf.Value))
                .WithPassword(password)
                .WithActive(user.Active)
                .WithFirstAccess(firstAccess)
                .WithProfile(new ProfileEntityBuilder()
                    .WithId(user.Profile.Id)
                    .WithRoleType(new Role(user.Profile.Role.Value))
                    .Build())
                .WithAccessCode(new AccessCodeEntityBuilder()
                    .WithId(user.AccessCode.Id)
                    .WithCode(user.AccessCode.Code)
                    .WithIsActive(user.AccessCode.IsActive)
                    .WithIsUserUpdatePassword(user.AccessCode.IsUserUpdatePassword)
                    .WithExperimentDate(user.AccessCode.ExperationDate)
                    .Build())
                .Build();
        }
    }
}

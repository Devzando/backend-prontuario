using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Profile;
using prontuario.Domain.Entities.User;
using prontuario.Domain.ValuesObjects;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.User;

namespace prontuario.Infra.Gateways.Mappers;

public class UserMapper
{
    public static UserEntity ToDomain(UserModel model)
    {
        return new UserEntityBuilder()
            .WithId(model.Id)
            .WithName(model.Name)
            .WithEmail(new Email(model.Email))
            .WithPassword(model.Password)
            .WithFirstAccess(model.FirstAccess)
            .WithActive(model.Active)
            .WithCpf(new CPF(model.Cpf))
            .WithAccessCode(new AccessCodeEntityBuilder()
                .WithId(model.AccessCode.Id)
                .WithCode(model.AccessCode.Code)
                .WithIsActive(model.AccessCode.IsActive)
                .WithExperimentDate(model.AccessCode.ExperationDate)
                .WithIsUserUpdatePassword(model.AccessCode.IsUserUpdatePassword)
                .Build())
            .WithProfile(new ProfileEntityBuilder()
                .WithId(model.Profile.Id)
                .WithRoleType(new Role(model.Profile.Role))
                .Build())
            .Build();
    }
}
using prontuario.Domain.Entities.AccessCode;
using prontuario.Domain.Entities.Profile;
using prontuario.Domain.ValuesObjects;

namespace prontuario.WebApi.ResponseModels
{
    public class UserResponseModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public Email Email { get; set; }
        public CPF Cpf { get; set; }
        public bool FirstAccess { get; set; }
        public bool Active { get; set; }
        public ProfileResponseModel Profile { get; set; }
        public AccessCodeResponseModel AccessCode { get; set; }

        public UserResponseModel(long? id, string name, Email email, CPF cpf, bool firstAccess, bool active, ProfileResponseModel profile, AccessCodeResponseModel accessCode)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
            FirstAccess = firstAccess;
            Active = active;
            Profile = profile;
            AccessCode = accessCode;
        }
    }
}

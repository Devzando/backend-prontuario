using prontuario.Domain.ValuesObjects;

namespace prontuario.WebApi.ResponseModels
{
    public class ProfileResponseModel
    {
        public Role Role { get; set; }

        public ProfileResponseModel(Role role) {
            Role = role;
        }
    }
}

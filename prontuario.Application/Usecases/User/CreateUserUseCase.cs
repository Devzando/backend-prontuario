using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.User;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.User
{
    public class CreateUserUseCase
    {
        private readonly IUserGateway _userGateway;
        private readonly IBcryptGateway _bcryptGateway;

        public CreateUserUseCase(IUserGateway userGateway, IBcryptGateway bcryptGateway)
        {
            _userGateway = userGateway;
            _bcryptGateway = bcryptGateway;
        }

        public async Task<ResultPattern<string>> Execute(CreateUserDTO data)
        {
            string hashedPassword = _bcryptGateway.GenerateHashPassword(data.Password);
            var userEntity = UserFactory.CreateUser(data, hashedPassword);
            var result = await _userGateway.Create(userEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}

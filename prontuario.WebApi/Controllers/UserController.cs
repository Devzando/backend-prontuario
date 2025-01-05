using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.AccessCode;
using prontuario.Application.Usecases.User;
using prontuario.Domain.Dtos.User;
using prontuario.WebApi.RequestModels.User;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.User;

namespace prontuario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Retorna o usuário pelo seu e-mail
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário retornado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Recurso não encontrado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetUserByEmail>> GetUserByEmail([FromQuery] string email, [FromServices] FindUserByEmail findUserByEmailUseCase)
        {
            var result = await findUserByEmailUseCase.Execute(email);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                // Retornando erro apropriado
                return result.ErrorDetails?.Status is 404
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }

            return Ok(UserResponseModel.CreateGetUserByEmail(result.Data));
        }

        /// <summary>
        /// Adiciona um novo usuário no sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário adicionado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="409">Erro de conflito</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<MessageSuccessResponseModel>> CreateUser(
            [FromBody] CreateUserRequest data, 
            [FromServices] CreateUserUseCase createUserUseCase, 
            [FromServices] CreateAccessCodeUseCase createAccessCodeUseCase)
        {
            var validator = new CreateUserValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            
            var accessCodeResult = createAccessCodeUseCase.Execute();
            
            var result = await createUserUseCase.Execute(new UserDtoBuilder()
                .WithName(data.Name)
                .WithEmail(data.Email)
                .WithCpf(data.Cpf)
                .WithProfile(new ProfileDTO(data.Profile.Role))
                .WithAccessCode(new AccessCodeDtoBuilder()
                    .WithCode(accessCodeResult.Data.Code)
                    .WithIsActive(accessCodeResult.Data.IsActive)
                    .WithIsUserUpdatePassword(accessCodeResult.Data.IsUserUpdatePassword)
                    .WithExpirationDate(accessCodeResult.Data.ExperationDate)
                    .Build())
                .Build());

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                // Retornando erro apropriado
                return result.ErrorDetails?.Status is 409 
                    ? Conflict(result.ErrorDetails) 
                    : BadRequest();
            }

            _logger.LogInformation("Usuário criado com sucesso");
            return Ok(new MessageSuccessResponseModel(result.Message));
        }

        /// <summary>
        /// Altera senha do usuário
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Senha alterada com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="409">Erro de conflito</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<MessageSuccessResponseModel>> UpdatePassword(
            [FromBody] UpdateUserPasswordRequest data,
            [FromServices] UpdateUserPasswordUseCase updateUserPasswordUseCase)
        {
            var validator = new UpdatePasswordUserValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString()); 
            }
            
            var resultUseCase = await updateUserPasswordUseCase.Execute(data.Email, data.Password, data.AccessCode);

            if (resultUseCase.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                resultUseCase.ErrorDetails!.Type = endpointUrl;
                
                // Retornando erro apropriado
                return resultUseCase.ErrorDetails?.Status is 409 
                    ? Conflict(resultUseCase.ErrorDetails) 
                    : BadRequest();
            }
            
            return Ok(new MessageSuccessResponseModel("Senha alterada com sucesso"));
        }
    }
    
}

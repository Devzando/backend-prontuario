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
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário retornado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserResponseModel>> GetUserByEmail([FromQuery] string email, [FromServices] FindUserByEmail findUserByEmailUseCase)
        {
            var result = await findUserByEmailUseCase.Execute(email);

            if (result.IsFailure)
            {
                return StatusCode(result.ErrorDetails?.Status ?? 500, new { message = result.Message });
            }

            return Ok(new UserResponseModel(
                result.Data.Id,
                result.Data.Name,
                result.Data.Email,
                result.Data.Cpf,
                result.Data.FirstAccess,
                result.Data.Active,
                new ProfileResponseModel(
                    result.Data.Profile.Role
                ),
                new AccessCodeResponseModel(
                    result.Data.AccessCode.Code,
                    result.Data.AccessCode.IsActive,
                    result.Data.AccessCode.IsUserUpdatePassword,
                    result.Data.AccessCode.ExperationDate
                )
            ));
        }

        /// <summary>
        /// Adiciona um novo usuário no sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Usuário adicionado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> CreateUser([FromBody] CreateUserRequest data, [FromServices] CreateUserUseCase createUserUseCase, [FromServices] CreateAccessCodeUseCase createAccessCodeUseCase)
        {
            var validator = new CreateUserValidator();
            var validationResult = validator.Validate(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            // Geração de código de acesso
            var accessCodeResult = createAccessCodeUseCase.Execute();
            if (accessCodeResult.IsFailure)
            {
                return StatusCode(accessCodeResult.ErrorDetails?.Status ?? 500, new { message = accessCodeResult.Message });
            }

            var result = await createUserUseCase.Execute(new CreateUserDTO(
                    data.Name,
                    data.Email,
                    data.Cpf,
                    data.Password,
                    data.FirstAccess,
                    data.Active,
                    new ProfileDTO(data.Profile.Role),
                    accessCodeResult.Data
            ));

            if (result.IsFailure)
            {
                return StatusCode(result.ErrorDetails?.Status ?? 500, new { message = result.Message });
            }

            _logger.LogInformation("Usuário criado com sucesso");
            return Ok(new MessageSuccessResponseModel(result.Message));
        }
    }
}

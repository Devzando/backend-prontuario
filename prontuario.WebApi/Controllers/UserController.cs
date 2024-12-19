using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.User;
using prontuario.WebApi.ResponseModels;

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
        public async Task<ActionResult<UserResponseModel>> GetUserByEmail([FromBody] string email, [FromServices] FindUserByEmail findUserByEmailUseCase)
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
    }
}

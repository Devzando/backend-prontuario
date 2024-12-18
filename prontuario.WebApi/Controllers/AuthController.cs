using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Auth;
using prontuario.WebApi.RequestModels.Auth;
using prontuario.WebApi.ResponseModels.Auth;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Auth;

namespace prontuario.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(ILogger<AuthController> logger) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<LoginResponse>> Login([FromBody] AuthRequest request, [FromServices] Login loginUseCase)
    {
        var validator = new AuthValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult .ToString());
        
        var useCaseResult = await loginUseCase.Execute(request.Email, request.Password);

        if (!useCaseResult.IsSuccess)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            useCaseResult.ErrorDetails!.Type = endpointUrl;

            // Retornando erro apropriado
            return useCaseResult.ErrorDetails?.Status is 400
                ? BadRequest(useCaseResult.ErrorDetails)
                : NotFound(useCaseResult.ErrorDetails);
        }
        
        logger.LogInformation($"Login realizado com sucesso");
        return Ok(new LoginResponse(useCaseResult.Data));
        
    }
}
using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Service;
using prontuario.WebApi.ResponseModels;

namespace prontuario.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(ILogger<ServiceController> _logger) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] long patientId, [FromServices] InitializeServiceUseCase initializeServiceUseCase)
    {
        var result = await initializeServiceUseCase.Execute(patientId);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
                
            return result.ErrorDetails?.Status == 404 
                ? NotFound(result.ErrorDetails) 
                : BadRequest();
        }
        
        _logger.LogInformation("Atendimento iniciado com sucesso");
        return Ok(new MessageSuccessResponseModel("Atendimento iniciado com sucesso"));
    }
}
using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Service;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.ResponseModels.Service;
using prontuario.WebApi.ResponseModels.Utils;

namespace prontuario.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ServiceController(ILogger<ServiceController> _logger) : ControllerBase
{
    /// <summary>
    /// Iniciar atendimento, colocar na fila de triagem
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <remarks>Enviar no corpo o id do paciente</remarks>
    /// <response code="200">Atendimento iniciado com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao iniciar atendimento</response>
    [HttpPost("initService")]
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

    /// <summary>
    /// Iniciar triagem
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <remarks>Enviar no corpo o id do atendimento</remarks>
    /// <response code="200">Triagem iniciada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao iniciar triagem</response>
    [HttpPost("initScreening")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> StartScreening([FromBody] long serviceId, [FromServices] InitializeScreeningUseCase initializeScreeningUseCase)
    {
        var result = await initializeScreeningUseCase.Execute(serviceId);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
                
            return result.ErrorDetails?.Status == 404 
                ? NotFound(result.ErrorDetails) 
                : BadRequest();
        }
        
        _logger.LogInformation("Triagem iniciada com sucesso");
        
        return Ok(new MessageSuccessResponseModel("Triagem iniciada com sucesso"));
    }
    
    /// <summary>
    /// Buscar todos os atendimentos por paciente
    /// </summary>
    /// <returns>Atendimentos retornados com sucesso</returns>
    /// <remarks>Enviar no corpo o id do paciente</remarks>
    /// <response code="200">Atendimentos retornados com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao buscar atendimentos</response>
    [HttpGet("patient/{patientId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PagedResponse<List<ServiceResponse>>>> FindAllByPatientId(
        [FromServices] FindAllServicesByPatientIdUseCase findAllServicesByPatientIdUseCase,
        [FromRoute] long patientId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await findAllServicesByPatientIdUseCase.Execute(patientId, pageNumber, pageSize);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
                
            return result.ErrorDetails?.Status == 404 
                ? NotFound(result.ErrorDetails) 
                : BadRequest();
        }
        
        _logger.LogInformation("Atendimentos retornados com sucesso");
        return Ok(UtilsResponseModel.CreateFindAllServicesByPatientId(result.Data, pageNumber, pageSize));
    }
}
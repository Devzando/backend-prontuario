using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.MedicalRecord;
using prontuario.Domain.Dtos.Anamnese;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.ResponseModels.MedicalRecord;

namespace prontuario.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedicalRecordController(ILogger<MedicalRecordController> _logger) : ControllerBase
{
    /// <summary>
    /// Adicionar Anamnese
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <remarks>Enviar no corpo o id do atendimento</remarks>
    /// <response code="200">Anamnese iniciada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao adicionar Anamnese</response>
    [HttpPost("anamnese")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> CreateAnamnese([FromBody] CreateAnamneseDTO data, [FromServices] CreateAnamneseUseCase createAnamneseUseCase)
    {
        var result = await createAnamneseUseCase.Execute(data);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
                
            return result.ErrorDetails?.Status == 404 
                ? NotFound(result.ErrorDetails) 
                : BadRequest();
        }

        _logger.LogInformation("Anamnese adicionado com sucesso");
        return Ok(new MessageSuccessResponseModel("Anamnese adicionado com sucesso"));
    }
    
    /// <summary>
    /// Buscar um prontuário pelo id
    /// </summary>
    /// <remarks>Obs: Precisa-se ter informação no banco</remarks>
    /// <returns>Prontuário retornado com sucesso</returns>
    /// <response code="200">Prontuário retornado com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao buscar prontuário</response>
    [HttpGet("{medicalRecordId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MedicalRecordResponse>> FindById([FromRoute] long medicalRecordId, [FromServices] FindMedicalRecordByIdUseCase findMedicalRecordByIdUseCase)
    {
        var result = await findMedicalRecordByIdUseCase.Execute(medicalRecordId);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
                
            return result.ErrorDetails?.Status == 404 
                ? NotFound(result.ErrorDetails) 
                : BadRequest();
        }

        _logger.LogInformation("Prontuário retornado com sucesso");
        return Ok(MedicalRecordResponseModels.CreateCompleteMedicalRecordResponse(result.Data));
    }
}
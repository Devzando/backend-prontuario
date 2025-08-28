using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Notes;
using prontuario.Domain.Dtos.Notes;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.ResponseModels.Notes;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Notes;

namespace prontuario.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotesController(ILogger<NotesController> logger) : ControllerBase
{
    /// <summary>
    /// Criar uma anotação para um paciente
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <response code="200">Anotação criada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao criar anotação</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> CreateNote([FromBody] CreateNotesDTO data, [FromServices] CreateNoteUseCase createNoteUseCase)
    {
        var validator = new CreateNoteValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }

        var result = await createNoteUseCase.Execute(data);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;

            return result.ErrorDetails?.Status == 404
                ? NotFound(result.ErrorDetails)
                : BadRequest();
        }

        logger.LogInformation("Anotação criada com sucesso");
        return Ok(new MessageSuccessResponseModel(result.Message));
    }

    /// <summary>
    /// Retornar todas as anotações de um paciente
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <response code="200">Anotações retornadas com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao retornar anotações</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<NotesResponse>>> GetNotes([FromQuery] long patientId, [FromServices] GetNotesUseCase getNotesUseCase)
    {
        var result = await getNotesUseCase.Execute(patientId);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
            return result.ErrorDetails?.Status == 404
                ? NotFound(result.ErrorDetails)
                : BadRequest();
        }

        logger.LogInformation("Anotações retornadas com sucesso");
        return Ok(NotesResponseModel.CreateGetAllNotesResponse(result.Data));
    }

    /// <summary>
    /// Retornar a quantidade de anotações de um paciente
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <response code="200">Quantidade de anotações retornada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao retornar quantidade de anotações</response>
    [HttpGet("Count")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<long>> GetNotesCount([FromQuery] long patientId, [FromServices] GetNotesCountUseCase getNotesCountUseCase)
    {
        var result = await getNotesCountUseCase.Execute(patientId);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;
            return result.ErrorDetails?.Status == 404
                ? NotFound(result.ErrorDetails)
                : BadRequest();
        }
        
        logger.LogInformation("Quantidade de anotações retornada com sucesso");
        return Ok(result.Data);
    }
}

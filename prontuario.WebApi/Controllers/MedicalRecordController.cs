using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.MedicalRecord;
using prontuario.Application.Usecases.PatientExam;
using prontuario.Application.Usecases.PatientMonitoring;
using prontuario.Domain.Dtos.Anamnese;
using prontuario.Domain.Dtos.PatientExam;
using prontuario.Domain.Dtos.PatientMonitoring;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Nursing;
using prontuario.WebApi.Validators.PatientExam;
using prontuario.WebApi.Validators.PatientMonitoring;
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
    /// Adicionar Monitoramento
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <remarks>Enviar no corpo o id do atendimento</remarks>
    /// <response code="200">Anamnese iniciada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao adicionar Anamnese</response>
    [HttpPost("PatientMonitoring")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> AddPatientMonitoring([FromBody] CreatePatientMonitoringDTO data, [FromServices] AddPatientMonitoringUseCase addPatientMonitoringUseCase)
    {
        var validator = new AddPatientMonitoringValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }

        var result = await addPatientMonitoringUseCase.Execute(data);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;

            return result.ErrorDetails?.Status == 404
                ? NotFound(result.ErrorDetails)
                : BadRequest();
        }

        _logger.LogInformation("Monitoramento adicionado com sucesso");
        return Ok(new MessageSuccessResponseModel("Monitoramento adicionado com sucesso"));
    }

    /// <summary>
    /// Adicionar Exame a paciente
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <remarks>Enviar no corpo o id do atendimento</remarks>
    /// <response code="200">Exame iniciada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao adicionar Exame</response>
    [HttpPost("PatientExam")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> AddExamToPatient([FromBody] List<CreatePatientExamDTO> data, [FromServices] AddPatientExamUseCase addPatientExamUseCase)
    {
        var validatorLista = new CreatePatientExamListValidator();
        //var validator = new CreatePatientExamValidator();

        var validationResult = await validatorLista.ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }

        var result = await addPatientExamUseCase.Execute(data);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;

            return result.ErrorDetails?.Status == 404
                ? NotFound(result.ErrorDetails)
                : BadRequest();
        }

        _logger.LogInformation("Exame adicionado com sucesso");
        return Ok(new MessageSuccessResponseModel("Exame adicionado com sucesso"));
    }

    /// <summary>
    /// Adicionar data de realização do exame do paciente
    /// </summary>
    /// <returns>Mensagem de sucesso na operação</returns>
    /// <remarks>Enviar no corpo o id do atendimento</remarks>
    /// <response code="200">Exame iniciada com Sucesso</response>
    /// <response code="400">Erro na operação</response>
    /// <response code="401">Acesso não autorizado</response>
    /// <response code="404">Erro ao adicionar Exame</response>
    [HttpPost("FinalizePatientExam")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MessageSuccessResponseModel>> FinalizePatientExam([FromBody] FinalizePatientExamDTO data, [FromServices] FinalizePatientExamUseCase finalizePatientExamUseCase)
    {
        var validator = new FinalizePatientExamValidator();
        var validationResult = await validator.ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.ToString());
        }

        var result = await finalizePatientExamUseCase.Execute(data);

        if (result.IsFailure)
        {
            // Construindo a URL dinamicamente
            var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
            result.ErrorDetails!.Type = endpointUrl;

            return result.ErrorDetails?.Status == 404
                ? NotFound(result.ErrorDetails)
                : BadRequest();
        }

        _logger.LogInformation("Data de realizacao adicionada com sucesso");
        return Ok(new MessageSuccessResponseModel("Data de realização adicionada com sucesso"));
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
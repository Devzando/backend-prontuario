using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Patient;
using prontuario.Domain.Dtos.Patient;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.ResponseModels.Patient;
using prontuario.WebApi.ResponseModels.Utils;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Patient;

namespace prontuario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(ILogger<PatientController> _logger) : ControllerBase
    {
        /// <summary>
        /// Adiciona um novo paciente no sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Paciente criado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreatePatientDTO data, [FromServices] CreatePatientUseCase createPatientUseCase)
        {
            var validator = new CreatePatientValidador();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createPatientUseCase.Execute(data);

            _logger.LogInformation("Paciente criado com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }
        
        /// <summary>
        /// Retorna pacientes com base nos filtros
        /// </summary>
        /// <remarks>
        /// É um filtro por vez.
        /// Para o paciente pode ser os seguintes Status: NO_SERVICE, IN_SERVICE
        /// Para o prontuário pode ser os seguintes Status: SCREENING, MEDICAL_CARE, NURSING, ADMISSION, OBSERVATION, MEDICAL_DISCHARGE
        /// Para as Classificações pode ser os seguintes Status: EMERGENCY, VERY_URGENT, URGENCY, LESS_SERIOUS, LIGHTWEIGHT
        /// Para o filter pode ser o seguinte: Cpf e Sus
        /// </remarks>
        /// <response code="200">Pacientes retornados com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Pacientes não encontrados</response>
        [HttpGet("filter")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedResponse<List<PatientResponse>>>> GetByFilterList(
            [FromServices] FindAllPatientUseCase getAllPatientUseCase,
            [FromQuery] string? filter = "",
            [FromQuery] string? status = "",
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {
            var result = await getAllPatientUseCase.Execute(filter, status, pageNumber, pageSize);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                return result.ErrorDetails?.Status == 404 
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }
            _logger.LogInformation("Pacientes recuperados com sucesso");
            return Ok(UtilsResponseModel.CreateFindAllListPatientPagedResponse(result.Data, pageNumber, pageSize));
        }
        
        /// <summary>
        /// Atualizar o status do paciente
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Status do paciente alterado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Erro ao alterar status do paciente</response>
        [HttpPut("status/{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageSuccessResponseModel>> UpdateStatus([FromRoute] long patientId, [FromServices] UpdatePatientStatusUseCase updatePatientStatusUseCase)
        {
            var result = await updatePatientStatusUseCase.Execute(patientId);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                return result.ErrorDetails?.Status == 404 
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }
            
            _logger.LogInformation("Paciente atualizado com sucesso");
            return Ok(new MessageSuccessResponseModel("Paciente atualizado com sucesso"));
        }

        /// <summary>
        /// Atualizar o paciente
        /// </summary>
        /// <remarks>Obs: Precisa-se reenviar os dados mesmo que o mesmo não esteja sendo alterado</remarks>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Paciente atualizado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Erro ao atualizar paciente</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Update([FromBody] UpdatePatientDTO data, [FromServices] UpdatePatientUseCase updatePatientUseCase)
        {
            var result = await updatePatientUseCase.Execute(data);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                return result.ErrorDetails?.Status == 404 
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }
            
            _logger.LogInformation("Paciente atualizado com sucesso");
            return Ok(new MessageSuccessResponseModel("Paciente atualizado com sucesso"));
        }
        
        /// <summary>
        /// Retorna um paciente baseando-se no id dele
        /// </summary>
        /// <returns>Paciente retornado com sucesso</returns>
        /// <response code="200">Paciente retornado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Erro ao buscar paciente</response>
        [HttpGet("{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientResponse>> FindById([FromRoute] long patientId, [FromServices] FindPatientByIdUseCase findPatientByIdUseCase)
        {
            var result = await findPatientByIdUseCase.Execute(patientId);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                return result.ErrorDetails?.Status == 404 
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }
            
            _logger.LogInformation("Paciente retornado com sucesso");
            return Ok(PatientResponseModel.CreateFindPatientById(result.Data!));
        }
    }
}

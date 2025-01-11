using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Patient;
using prontuario.Domain.Dtos.Patient;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.ResponseModels.Patient;
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
        /// Retorna todos os pacientes cadastrados no sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Pacientes retornados com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<List<PatientResponse>>> GetAll([FromServices] GetAllPatientsUseCase getAllPatientsUseCase)
        {
            var result = await getAllPatientsUseCase.Execute();
            _logger.LogInformation("Pacientes recuperados com sucesso");
            return Ok(result.Data.Select(PatientResponseModel.CreateGetAllPatientResponse).ToList());
        }

        /// <summary>
        /// Retornar paciente com base em filtro de CPF ou SUS
        /// </summary>
        /// <response code="200">Paciente retornado com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Paciente não encontrado</response>
        [HttpGet("{filter}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PatientResponse>> GetByFilter([FromRoute] string filter, [FromServices] GetPatientsByFilterUseCase getPatientsByFilterUseCase)
        {
            var result = await getPatientsByFilterUseCase.Execute(filter);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                return result.ErrorDetails?.Status == 404 
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }
            _logger.LogInformation("Paciente recuperado com sucesso");
            return Ok(PatientResponseModel.CreateGetAllPatientResponse(result.Data));
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
    }
}

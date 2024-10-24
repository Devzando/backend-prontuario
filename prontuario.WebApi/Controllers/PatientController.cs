using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Patient;
using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Errors;
using prontuario.WebApi.RequestModels.Patient;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Patient;

namespace prontuario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

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
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreatePatientRequest data, [FromServices] CreatePatientUseCase createPatientUseCase)
        {
            var validator = new CreatePatientValidador();
            var validationResult = validator.Validate(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }
            var result = await createPatientUseCase.Execute(new CreatePatientDTO(
                    data.Name,
                    data.BirthDate,
                    data.Sus,
                    data.Cpf,
                    data.Rg,
                    data.Phone,
                    new AddressDTO(
                            data.Address.Cep,
                            data.Address.Street,
                            data.Address.City,
                            data.Address.Number
                        ),
                    new EmergencyContactDetailsDTO(
                            data.EmergencyContactDetails.Name,
                            data.EmergencyContactDetails.Phone,
                            data.EmergencyContactDetails.Relationship
                        )
                ));

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
        public async Task<ActionResult<List<PatientResponseModel>>> GetAll([FromServices] GetAllPatientsUseCase getAllPatientsUseCase)
        {
            var result = await getAllPatientsUseCase.Execute();
            return Ok(result.Data.Select(patient => new PatientResponseModel(
                patient.Id,
                patient.Name,
                patient.BirthDate,
                patient.Sus,
                patient.Cpf,
                patient.Rg,
                patient.Phone,
                new AddressResponseModel(
                    patient.AddressEntity.Cep,
                    patient.AddressEntity.Street,
                    patient.AddressEntity.City,
                    patient.AddressEntity.Number
                ),
                new EmergencyContactDetailsResponseModel(
                    patient.EmergencyContactDetailsEntity.Name,
                    patient.EmergencyContactDetailsEntity.Phone,
                    patient.EmergencyContactDetailsEntity.Relationship
                )
            )).ToList());
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
        public async Task<ActionResult<PatientResponseModel>> GetByFilter([FromRoute] string filter, [FromServices] GetPatientsByFilterUseCase getPatientsByFilterUseCase)
        {
            var result = await getPatientsByFilterUseCase.Execute(filter);

            if (result.IsFailure)
            {
                return StatusCode(result.ErrorDetails?.Status ?? 500, new { message = result.Message });
            }
            return Ok(new PatientResponseModel(
                result.Data.Id,
                result.Data.Name,
                result.Data.BirthDate,
                result.Data.Sus,
                result.Data.Cpf,
                result.Data.Rg,
                result.Data.Phone,
                new AddressResponseModel(
                    result.Data.AddressEntity.Cep,
                    result.Data.AddressEntity.Street,
                    result.Data.AddressEntity.City,
                    result.Data.AddressEntity.Number
                ),
                new EmergencyContactDetailsResponseModel(
                    result.Data.EmergencyContactDetailsEntity.Name,
                    result.Data.EmergencyContactDetailsEntity.Phone,
                    result.Data.EmergencyContactDetailsEntity.Relationship
                )
            ));
        }
    }
}

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
    }
}

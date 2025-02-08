using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Patient;
using prontuario.Application.Usecases.MedicalCare;
using prontuario.Domain.Dtos.MedicalCare;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.MedicalCare;

namespace prontuario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalCareController(ILogger<MedicalCareController> _logger) : ControllerBase
    {
        /// <summary>
        /// Adiciona uma nova prescrição de exame ao sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Prescrição criada com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreateExamPrescriptionDTO data, [FromServices] CreateExamPrescriptionUseCase createExamPrescriptionUseCase)
        {
            var validator = new CreateExamPrescriptionValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createExamPrescriptionUseCase.Execute(data);

            _logger.LogInformation("Prescrição de exame criada com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }       
        
        /// <summary>
        /// Adiciona uma nova prescrição médica ao sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Prescrição criada com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreateMedicalPrescriptionDTO data, [FromServices] CreateMedicalPrescriptionUseCase createMedicalPrescriptionUseCase)
        {
            var validator = new CreateMedicalPrescriptionValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createMedicalPrescriptionUseCase.Execute(data);

            _logger.LogInformation("Prescrição médica criada com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }

        /// <summary>
        /// Adiciona uma nova hipótese médica ao sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Hipótese criada com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreateMedicalHypothesisDTO data, [FromServices] CreateMedicalHypothesisUseCase createMedicalHypothesisUseCase)
        {
            var validator = new CreateMedicalHypothesisValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createMedicalHypothesisUseCase.Execute(data);

            _logger.LogInformation("Hipótese médica criada com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }

        /// <summary>
        /// Adicionar necessidades Psicobiólogicas
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Necessidades Psicobiólogicas criadas com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreatePsychobiologicalNeedsDTO data, [FromServices] CreatePsychobiologicalNeedsUseCase createPsychobiologicalNeedsUseCase)
        {
            var validator = new CreatePsychobiologicalNeedsValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createPsychobiologicalNeedsUseCase.Execute(data);

            _logger.LogInformation("Necessidades Psicobiólogicas criadas com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }

        /// <summary>
        /// Adicionar informações Neurologicas
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Informações Neurologicas criadas com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreateNeuroDTO data, [FromServices] CreateNeuroUseCase createNeurologicalInformationUseCase)
        {
            var validator = new CreateNeuroValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createNeurologicalInformationUseCase.Execute(data);

            _logger.LogInformation("Informações Neurologicas criadas com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }       

        /// <summary>
        /// Adicionar informações cardiologicas
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Informações Cardiológicas criadas com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreateCardioDTO data, [FromServices] CreateCardioUseCase createCardiologicalInformationUseCase)
        {
            var validator = new CreateCardioValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createCardiologicalInformationUseCase.Execute(data);

            _logger.LogInformation("Informações Cardiológicas criadas com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }
    }

    public class CreateNeuroUseCase
    {
    }

    public class CreateCardioUseCase
    {
    }
}

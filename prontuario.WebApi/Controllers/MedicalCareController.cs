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
        /// Adicionar cardio, neuro e necessidades Psicobiólogicas
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Cárdio, neuro e necessidades Psicobiólogicas criadas com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create(
            [FromBody] CreateMedicalCareDTO data,
            [FromServices] CreateMedicalCareUseCase createMedicalCareUseCase)
        {
            var validator = new CreateMedicalCareValidar();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createMedicalCareUseCase.Execute(data);

            _logger.LogInformation("Cárdio, neuro e necessidades Psicobiólogicas criadas com sucesso");

            return Ok(new MessageSuccessResponseModel("Cárdio, neuro e necessidades Psicobiólogicas criadas com sucesso"));
        }

    }
}

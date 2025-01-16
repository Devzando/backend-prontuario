using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Patient;
using prontuario.Domain.Dtos.Nursing;
using prontuario.Domain.Dtos.Patient;
using prontuario.WebApi.ResponseModels;

using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Nursing;
using prontuario.WebApi.Validators.Patient;

namespace prontuario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NursingController(ILogger<NursingController> _logger) : ControllerBase
    {
        /// <summary>
        /// Adiciona uma nova anotação de enfermagem ao sistema
        /// </summary>
        /// <returns>Mensagem de sucesso na operação</returns>
        /// <response code="200">Nota criada com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MessageSuccessResponseModel>> Create([FromBody] CreateNursingNoteDTO data, [FromServices] CreateNursingNoteUseCase createNursingNoteUseCase)
        {
            var validator = new CreateNursingNoteValidator();
            var validationResult = await validator.ValidateAsync(data);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.ToString());
            }

            var result = await createNursingNoteUseCase.Execute(data);

            _logger.LogInformation("Anotação de enfermagem criada com sucesso");

            return Ok(new MessageSuccessResponseModel(result.Message));
        }       
    }
}

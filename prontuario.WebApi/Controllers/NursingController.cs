using Microsoft.AspNetCore.Mvc;
using prontuario.Application.Usecases.Patient;
using prontuario.Domain.Dtos.Nursing;
using prontuario.WebApi.ResponseModels;
using prontuario.WebApi.ResponseModels.Nursing;
using prontuario.WebApi.Validators;
using prontuario.WebApi.Validators.Nursing;
using prontuario.WebApi.ResponseModels.Utils;

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

        /// <summary>
        /// Retorna Anotações de enfermagem
        /// </summary>
        /// <response code="200">Anotações retornados com Sucesso</response>
        /// <response code="400">Erro na operação</response>
        /// <response code="401">Acesso não autorizado</response>
        /// <response code="404">Anotações não encontradas</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedResponse<List<NursingResponse>>>> GetByFilterList(
            [FromServices] FindAllNursingNoteUseCase getAllNursingNoteUseCase,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10
            )
        {
            var result = await getAllNursingNoteUseCase.Execute(pageNumber, pageSize);

            if (result.IsFailure)
            {
                // Construindo a URL dinamicamente
                var endpointUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{HttpContext.Request.Path}";
                result.ErrorDetails!.Type = endpointUrl;
                
                return result.ErrorDetails?.Status == 404 
                    ? NotFound(result.ErrorDetails) 
                    : BadRequest();
            }
            _logger.LogInformation("Anotações de enfermagem recuperadas com sucesso");
            return Ok(UtilsResponseModel.CreateFindAllListNursingPagedResponse(result.Data, pageNumber, pageSize));
        }
        
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prontuario.Domain.Errors;

namespace prontuario.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        [HttpPost]
        public async Task<ResultPattern<string>> Create([FromBody] CreatePatientDTO data)
        {
            var result = await _createPatientUseCase.Execute(data);
            if(result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}

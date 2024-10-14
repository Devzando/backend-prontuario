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
        public async Task<ResultPattern<string>> Create()
        {
            return ResultPattern<string>.SuccessResult("Paciente criado com sucesso");
        }
    }
}

using prontuario.Application.Gateways;
using prontuario.Domain.Errors;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Utils;

namespace prontuario.Application.Usecases.Patient
{
    public class GetAllPatientsUseCase(IGatewayPatient gatewayPatient)
    {
        public async Task<ResultPattern<PagedResult<List<PatientEntity>>>> Execute(int pageNumber, int pageSize)
        {
            var result = await gatewayPatient.GetAll(pageNumber, pageSize);
            return ResultPattern<PagedResult<List<PatientEntity>>>.SuccessResult(result);
        }
    }
}

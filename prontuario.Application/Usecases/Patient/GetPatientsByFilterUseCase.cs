using prontuario.Application.Gateways;
using prontuario.Domain.Errors;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Application.Usecases.Patient
{
    public class GetPatientsByFilterUseCase(IGatewayPatient gatewayPatient)
    {
        public async Task<ResultPattern<PatientEntity>> Execute(string filter, string status)
        {
            var result = await gatewayPatient.GetByFilter(filter, status);
            return result != null 
                ? ResultPattern<PatientEntity>.SuccessResult(result) 
                : ResultPattern<PatientEntity>.FailureResult("Paciente não encontrado!", 404);
        }
    }
}

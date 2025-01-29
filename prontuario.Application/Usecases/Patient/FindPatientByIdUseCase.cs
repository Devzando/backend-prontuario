using prontuario.Application.Gateways;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Patient;

public class FindPatientByIdUseCase(IGatewayPatient gatewayPatient)
{
    public async Task<ResultPattern<PatientEntity?>> Execute(long patientId)
    {
        var patient = await gatewayPatient.GetById(patientId);
        return ResultPattern<PatientEntity?>.SuccessResult(patient);
    }
}
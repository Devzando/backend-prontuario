using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Patient;

public class UpdatePatientStatusUseCase(IGatewayPatient gatewayPatient)
{
    public async Task<ResultPattern<string>> Execute(long patientId)
    {
        var patient = await gatewayPatient.GetById(patientId);
        if(patient is null)
            return ResultPattern<string>.FailureResult("Erro ao alterar status do paciente", 404);

        var updatedPatient = PatientFactory.CreatePatient(patient);
        await gatewayPatient.Save(updatedPatient);
        return ResultPattern<string>.SuccessResult();
    }
}
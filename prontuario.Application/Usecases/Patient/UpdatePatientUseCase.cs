using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Patient;

public class UpdatePatientUseCase(IGatewayPatient gatewayPatient)
{
    public async Task<ResultPattern<string>> Execute(UpdatePatientDTO data)
    {
        var patient = await gatewayPatient.GetById(data.Id);
        var patientUpdated = PatientFactory.CreatePatientToUpdate(data, patient!);
        await gatewayPatient.Update(patientUpdated);
        return ResultPattern<string>.SuccessResult();
    }
}
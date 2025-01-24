using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Patient
{
    public class CreatePatientUseCase(IGatewayPatient gatewayPatient)
    {
        public async Task<ResultPattern<string>> Execute(CreatePatientDTO data)
        {
            var patient = await gatewayPatient.GetByCpf(data.Cpf);
            if(patient != null)
                return ResultPattern<string>.FailureResult("Erro ao cadastrar o patient", 400);
            var patientEntity = PatientFactory.CreatePatient(data);
            await gatewayPatient.Save(patientEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}

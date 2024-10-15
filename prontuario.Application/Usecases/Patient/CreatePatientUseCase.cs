using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.Patient
{
    public class CreatePatientUseCase
    {
        private readonly IGatewayPatient _gatewayPatient;

        public CreatePatientUseCase(IGatewayPatient gatewayPatient)
        {
            _gatewayPatient = gatewayPatient;
        }

        public async Task<ResultPattern<string>> Execute(CreatePatientDTO data)
        {
            var patientEntity = PatientFactory.CreatePatient(data);
            var result = await _gatewayPatient.Create(patientEntity);
            return ResultPattern<string>.SuccessResult();
        }
    }
}

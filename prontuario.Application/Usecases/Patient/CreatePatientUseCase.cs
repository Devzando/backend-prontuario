using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Patient;
using prontuario.Domain.Entities;
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

        public async Task<ResultPattern<PatientEntity>> Execute(CreatePatientDTO data)
        {
            var patientEntity = PatientFactory.CreatePatient(data);
            var result = await _gatewayPatient.Create(patientEntity);
            if(result == null)
            {
                return ResultPattern<PatientEntity>.FailureResult(
                   detail: "Erro ao criar novo paciente",
                   statusCode: 400,
                   title: "Erro ao criar paciente"
               );
            }

            return ResultPattern<PatientEntity>.SuccessResult(result);
        }
    }
}

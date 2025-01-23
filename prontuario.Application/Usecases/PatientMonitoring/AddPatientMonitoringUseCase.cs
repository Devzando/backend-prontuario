using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.Nursing;
using prontuario.Domain.Dtos.PatientMonitoring;
using prontuario.Domain.Entities.PatientMonitoring;
using prontuario.Domain.Errors;

namespace prontuario.Application.Usecases.PatientMonitoring
{
    public class AddPatientMonitoringUseCase(IMedicalRecordGateway medicalRecordGateway, IServiceGateway serviceGateway)
    {
        public async Task<ResultPattern<string>> Execute(CreatePatientMonitoringDTO data)
        {
            var medicalRecord = await medicalRecordGateway.GetById(data.MedidacalRecordId);
            if (medicalRecord is null)
                return ResultPattern<string>.FailureResult("Erro ao adicionar monitoramento", 404);

            var patienMonitoring = PatientMonitoringFactory.CreatePatientMonitoringEntity(data);
            patienMonitoring.MedicalRecord = medicalRecord;
            medicalRecord.PatientMonitoring = patienMonitoring;

            await medicalRecordGateway.Save(medicalRecord);

            return ResultPattern<string>.SuccessResult();
        }
    }
}

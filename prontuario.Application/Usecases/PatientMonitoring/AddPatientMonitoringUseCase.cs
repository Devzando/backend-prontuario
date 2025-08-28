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
            var medicalRecord = await medicalRecordGateway.FindById(data.MedicalRecordId);
            if (medicalRecord is null)
                return ResultPattern<string>.FailureResult("Erro ao adicionar monitoramento", 404);

            // Criar a entidade de monitoramento do paciente
            var patientMonitoring = PatientMonitoringFactory.CreatePatientMonitoringEntity(data);
            patientMonitoring.MedicalRecord = medicalRecord;

            // Inicializar a lista se for nula
            medicalRecord.PatientMonitoring ??= new List<PatientMonitoringEntity>();

            // Adicionar o monitoramento à coleção
            medicalRecord.PatientMonitoring.Add(patientMonitoring);

            // Salvar as alterações no banco
            await medicalRecordGateway.Save(medicalRecord);

            return ResultPattern<string>.SuccessResult();
        }
    }
}

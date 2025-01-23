using prontuario.Domain.Entities.Patient;
using prontuario.WebApi.ResponseModels.Address;
using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.EmergencyContactDetails;
using prontuario.WebApi.ResponseModels.MedicalRecord;
using prontuario.WebApi.ResponseModels.PatientMonitoring;
using prontuario.WebApi.ResponseModels.Service;

namespace prontuario.WebApi.ResponseModels.Patient
{
    public class PatientResponseModel
    {
        public static PatientResponse CreateGetAllPatientResponse(PatientEntity entity)
        {
            return new PatientResponse(
                entity.Id,
                entity.Name,
                entity.SocialName,
                entity.BirthDate,
                entity.Sus?.Value,
                entity.Cpf.Value,
                entity.Rg?.Value,
                entity.Phone?.Value,
                entity.MotherName,
                entity.Status?.Value,
                new AddressResponse(
                    entity.AddressEntity.Id,
                    entity.AddressEntity.Cep?.Value,
                    entity.AddressEntity.City,
                    entity.AddressEntity.Street,
                    entity.AddressEntity.Number,
                    entity.AddressEntity.Neighborhood
                ),
                entity.EmergencyContactDetailsEntity.Select(em => new EmergencyContactDetailsResponse(
                    em.Id,
                    em.Name,
                    em.Phone?.Value,
                    em.Relationship?.Value
                )).ToList(),
                entity.ServicesEntity?.Where(service => service.PatientId == entity.Id).Select(service => new ServiceResponseBuilder()
                    .WithId(service.Id)
                    .WithServiceDate(service.ServiceDate)
                    .WithServiceStatus(service.ServiceStatus.Value)
                    .WithMedicalRecordResponse(service.MedicalRecordEntity != null ?
                         new MedicalRecordResponse(
                            service.MedicalRecordEntity.Id,
                            service.MedicalRecordEntity.Status.Value,
                            service.MedicalRecordEntity.Anamnese != null ?
                                new AnamneseResponse(
                                    service.MedicalRecordEntity.Anamnese.Id,
                                    service.MedicalRecordEntity.Anamnese.ClassificationStatus.Value)
                                : null,
                            service.MedicalRecordEntity.PatientMonitoring != null ?
                                new PatientMonitoringResponse(service.MedicalRecordEntity.PatientMonitoring.Id)
                                : null)
                        : null)
                    .Build())
                    .ToList());
        }
        public static List<PatientResponse> CreateGetAllPatientResponse(List<PatientEntity> entity)
        {
            return entity.Select(patient => new PatientResponse(
                patient.Id,
                patient.Name,
                patient.SocialName,
                patient.BirthDate,
                patient.Sus?.Value,
                patient.Cpf.Value,
                patient.Rg?.Value,
                patient.Phone?.Value,
                patient.MotherName,
                patient.Status?.Value,
                new AddressResponse(
                    patient.AddressEntity.Id,
                    patient.AddressEntity.Cep?.Value,
                    patient.AddressEntity.City,
                    patient.AddressEntity.Street,
                    patient.AddressEntity.Number,
                    patient.AddressEntity.Neighborhood
                ),
                patient.EmergencyContactDetailsEntity.Select(em => new EmergencyContactDetailsResponse(
                    em.Id,
                    em.Name,
                    em.Phone?.Value,
                    em.Relationship?.Value
                )).ToList(),
                patient.ServicesEntity?.Where(service => service.PatientId == service.Id).Select(service =>
                        new ServiceResponseBuilder()
                            .WithId(service.Id)
                            .WithServiceDate(service.ServiceDate)
                            .WithServiceStatus(service.ServiceStatus.Value)
                            .WithMedicalRecordResponse(service.MedicalRecordEntity != null
                                ? new MedicalRecordResponse(
                                    service.MedicalRecordEntity.Id,
                                    service.MedicalRecordEntity.Status.Value,
                                    service.MedicalRecordEntity.Anamnese != null
                                        ? new AnamneseResponse(
                                            service.MedicalRecordEntity.Anamnese.Id,
                                            service.MedicalRecordEntity.Anamnese.ClassificationStatus.Value)
                                        : null,
                                    service.MedicalRecordEntity.PatientMonitoring != null
                                        ? new PatientMonitoringResponse(
                                            service.MedicalRecordEntity.PatientMonitoring.Id)
                                        : null)
                                : null)
                            .Build())
                    .ToList())).ToList();
        }

    }
}

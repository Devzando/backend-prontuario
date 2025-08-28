using prontuario.Domain.Entities.Service;
using prontuario.WebApi.ResponseModels.MedicalRecord;
using prontuario.WebApi.ResponseModels.MedicalCare;
using prontuario.WebApi.ResponseModels.Patient;


namespace prontuario.WebApi.ResponseModels.Service;

public class ServiceResponseModel
{
    public static ServiceResponse CreateFindAllServiceByPatientId(ServiceEntity serviceEntity)
    {
        var service = new ServiceResponseBuilder()
            .WithId(serviceEntity.Id)
            .WithServiceDate(serviceEntity.ServiceDate)
            .WithServiceStatus(serviceEntity.ServiceStatus)
            .WithMedicalRecordResponse(serviceEntity.MedicalRecordEntity == null 
                ? null 
                : MedicalRecordResponseModels.CreateCompleteMedicalRecordResponse(serviceEntity.MedicalRecordEntity!))
            .WithMedicalCareResponse(serviceEntity.MedicalCareEntity == null 
                ? null 
                : MedicalCareResponseModel.CreateCompleteMedicalCareResponse(serviceEntity.MedicalCareEntity!))
            .Build();

        return service;
    }
    
    public static ServiceResponse CreateCompleteService(ServiceEntity serviceEntity)
    {
        var service = new ServiceResponseBuilder()
            .WithId(serviceEntity.Id)
            .WithServiceDate(serviceEntity.ServiceDate)
            .WithServiceStatus(serviceEntity.ServiceStatus)
            .WithMedicalRecordResponse(serviceEntity.MedicalRecordEntity == null 
                ? null 
                : MedicalRecordResponseModels.CreateCompleteMedicalRecordResponse(serviceEntity.MedicalRecordEntity!))
            .WithMedicalCareResponse(serviceEntity.MedicalCareEntity == null 
                ? null 
                : MedicalCareResponseModel.CreateCompleteMedicalCareResponse(serviceEntity.MedicalCareEntity!))
            .Build();

        return service;
    }
}
using prontuario.Domain.Entities.Service;
using prontuario.WebApi.ResponseModels.MedicalRecord;

namespace prontuario.WebApi.ResponseModels.Service;

public class ServiceResponseModel
{
    public static ServiceResponse CreateFindAllServiceByPatientId(ServiceEntity serviceEntity)
    {
        var service = new ServiceResponseBuilder()
            .WithId(serviceEntity.Id)
            .WithServiceDate(serviceEntity.ServiceDate)
            .WithServiceStatus(serviceEntity.ServiceStatus)
            .WithMedicalRecordResponse(MedicalRecordResponseModels.CreateCompleteMedicalRecordResponse(serviceEntity.MedicalRecordEntity!))
            .Build();

        return service;
    }
    
    public static ServiceResponse CreateCompleteService(ServiceEntity serviceEntity)
    {
        var service = new ServiceResponseBuilder()
            .WithId(serviceEntity.Id)
            .WithServiceDate(serviceEntity.ServiceDate)
            .WithServiceStatus(serviceEntity.ServiceStatus)
            .WithMedicalRecordResponse(MedicalRecordResponseModels.CreateCompleteMedicalRecordResponse(serviceEntity.MedicalRecordEntity!))
            .Build();

        return service;
    }
}
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Enums;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories;

public class ServiceFactory
{
    public static ServiceEntity CreateServiceToInitializeService(PatientEntity patient)
    {
        patient.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        
        return new ServiceEntityBuilder()
            .WithServiceDate(DateTime.Now)
            .WithPatient(patient)
            .WithServiceStatus(new ServiceStatus(null))
            .Build();
    }

    public static ServiceEntity CreateServiceToInitializeScreening(ServiceEntity service, MedicalRecordEntity medicalRecord)
    {
        service.MedicalRecordEntity = medicalRecord;
        return service;
    }
}
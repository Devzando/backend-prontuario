using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.Enums;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories;

public class ServiceFactory
{
    public static ServiceEntity CreateService(PatientEntity patient)
    {
        return new ServiceEntityBuilder()
            .WithPatient(patient)
            .WithServiceDate(DateTime.Now)
            .Build();
    }
}
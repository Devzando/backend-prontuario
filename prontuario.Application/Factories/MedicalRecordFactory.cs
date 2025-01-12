using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Enums;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories;

public class MedicalRecordFactory
{
    public static MedicalRecordEntity CreateMedicalRecord()
    {
        return new MedicalRecordEntityBuilder()
            .WithStatus(new MedicalRecordStatus(MedicalRecordStatusType.SCREENING.ToString()))
            .WithStatusInCaseOfAdmission(new MedicalRecordStatus(null))
            .Build();
    }
}
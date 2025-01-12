using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Enums;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories;

public class MedicalRecordFactory
{
    public static MedicalRecordEntity CreateMedicalRecordToInitScreening()
    {
        return new MedicalRecordEntityBuilder()
            .WithStatus(new MedicalRecordStatus(MedicalRecordStatusType.SCREENING.ToString()))
            .WithStatusInCaseOfAdmission(new MedicalRecordStatus(null))
            .Build();
    }
    public static MedicalRecordEntity CreateMedicalRecordWithAnamnese(MedicalRecordEntity medicalRecordEntity, AnamneseEntity anamneseEntity)
    {
        medicalRecordEntity.Anamnese = anamneseEntity;
        medicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.MEDICAL_CARE.ToString());
        return medicalRecordEntity;
    }
}
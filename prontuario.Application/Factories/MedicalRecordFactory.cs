using prontuario.Domain.Dtos.MedicalRecord;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
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

    public static (MedicalRecordEntity medicalRecordEntity, PatientEntity patientEntity) ChangeMedicalRecordStatus(ChangeMedicalRecordStatusDTO data)
    {
        if(data.Status == "alta")
        {
            data.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.NO_SERVICE.ToString());
            data.PatientEntity.Status = new PatientStatus(PatientStatusType.NO_SERVICE.ToString());
        } else if (data.Status == "lab")
        {
            data.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.SCREENING.ToString());
            data.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        } else if (data.Status == "enfermagem")
        {
            data.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.NURSING.ToString());
            data.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        } else if (data.Status == "internacao")
        {
            data.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.ADMISSION.ToString());
            data.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        } else {
            data.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.MEDICAL_CARE.ToString());
            data.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        }

        return (data.MedicalRecordEntity, data.PatientEntity);
    }
}
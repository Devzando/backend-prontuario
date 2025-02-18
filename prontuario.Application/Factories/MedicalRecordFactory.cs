using prontuario.Domain.Dtos.MedicalRecord;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalRecord;
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
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

    public static ServiceEntity ChangeMedicalRecordStatus(ChangeMedicalRecordStatusDTO data, ServiceEntity serviceEntity)
    {
        if(data.Status == "alta")
        {
            serviceEntity.MedicalRecordEntity!.Status = new MedicalRecordStatus(MedicalRecordStatusType.NO_SERVICE.ToString());
            serviceEntity.PatientEntity.Status = new PatientStatus(PatientStatusType.NO_SERVICE.ToString());
            serviceEntity.ServiceStatus = data.ServiceStatus;
        } else if (data.Status == "lab")
        {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.SCREENING.ToString());
            }
            serviceEntity.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        } else if (data.Status == "enfermagem")
        {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.NURSING.ToString());
            }
            serviceEntity.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        } else if (data.Status == "internacao")
        {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.ADMISSION.ToString());
                serviceEntity.MedicalRecordEntity.StatusInCaseOfAdmission = new MedicalRecordStatus(MedicalRecordStatusType.ADMISSION.ToString());
            }
            serviceEntity.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        } else {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.MEDICAL_CARE.ToString());
            }
            serviceEntity.PatientEntity.Status = new PatientStatus(PatientStatusType.IN_SERVICE.ToString());
        }

        return serviceEntity;
    }
}
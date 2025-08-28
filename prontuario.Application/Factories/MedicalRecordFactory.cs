using prontuario.Domain.Dtos.MedicalRecord;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.MedicalCare;
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
        if(data.Status == MedicalRecordStatusType.MEDICAL_DISCHARGE.ToString())
        {
            serviceEntity.MedicalRecordEntity!.Status = new MedicalRecordStatus(MedicalRecordStatusType.MEDICAL_DISCHARGE.ToString());
            serviceEntity.PatientEntity.Status = new PatientStatus(PatientStatusType.NO_SERVICE.ToString());
            serviceEntity.ServiceStatus = new ServiceStatus(data.ServiceStatus).Value;
        } else if (data.Status == MedicalRecordStatusType.NURSING.ToString())
        {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.NURSING.ToString());
            }
        } else if (data.Status == MedicalRecordStatusType.ADMISSION.ToString()) 
        {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.ADMISSION.ToString());
                serviceEntity.MedicalRecordEntity.StatusInCaseOfAdmission = new MedicalRecordStatus(MedicalRecordStatusType.ADMISSION.ToString());
            }
        } else {
            if (serviceEntity.MedicalRecordEntity != null)
            {
                serviceEntity.MedicalRecordEntity.Status = new MedicalRecordStatus(MedicalRecordStatusType.MEDICAL_CARE.ToString());
            }
        }

        return serviceEntity;
    }
}
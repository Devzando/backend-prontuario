using prontuario.Domain.Dtos.PatientExam;
using prontuario.Domain.Dtos.PatientMedication;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Factories
{
    public class PatientMedicationFactory
    {
        public static PatientMedicationEntity CreatePatientMedicationEntity(CreatePatientMedicationDTO data)
        {
            return new PatientMedicationEntityBuilder()
                .WithMedicalRecordId(data.MedicalRecordId)
                .WithDescription(data.Description)
                .WithPrescriptionDate(data.PrescriptionDate)
                .WithExecutionDate(data.ExecutionDate)
                .Build();
        }
    }
}

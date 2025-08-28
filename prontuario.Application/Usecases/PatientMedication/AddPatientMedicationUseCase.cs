using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.PatientExam;
using prontuario.Domain.Dtos.PatientMedication;
using prontuario.Domain.Dtos.PatientMonitoring;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using prontuario.Domain.Entities.PatientMonitoring;
using prontuario.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Usecases.PatientExam
{
    public class AddPatientMedicationUseCase(IMedicalRecordGateway medicalRecordGateway, IServiceGateway serviceGateway)
    {
        public async Task<ResultPattern<string>> Execute(List<CreatePatientMedicationDTO> data)
        {
            if (data == null || data.Count == 0)
                return ResultPattern<string>.FailureResult("Nenhuma medicação fornecida", 400);

            var groupedByMedicalRecord = data.GroupBy(d => d.MedicalRecordId);

            foreach (var group in groupedByMedicalRecord)
            {
                var medicalRecordId = group.Key;
                var medicalRecord = await medicalRecordGateway.FindById(medicalRecordId);
                if (medicalRecord is null)
                    return ResultPattern<string>.FailureResult($"Erro ao adicionar medicações, ficha médica {medicalRecordId} não encontrada", 404);

                medicalRecord.PatientMedications ??= new List<PatientMedicationEntity>();

                foreach (var medicationDto in group)
                {
                    var medication = PatientMedicationFactory.CreatePatientMedicationEntity(medicationDto);
                    medication.MedicalRecord = medicalRecord;
                    medicalRecord.PatientMedications.Add(medication);
                }

                await medicalRecordGateway.Save(medicalRecord);
            }

            return ResultPattern<string>.SuccessResult();
        }
    }
}

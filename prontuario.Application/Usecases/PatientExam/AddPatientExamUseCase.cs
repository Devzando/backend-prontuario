using prontuario.Application.Factories;
using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.PatientExam;
using prontuario.Domain.Dtos.PatientMonitoring;
using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMonitoring;
using prontuario.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Usecases.PatientExam
{
    public class AddPatientExamUseCase(IMedicalRecordGateway medicalRecordGateway, IServiceGateway serviceGateway)
    {
        public async Task<ResultPattern<string>> Execute(List<CreatePatientExamDTO> data)
        {
            if (data == null || data.Count == 0)
                return ResultPattern<string>.FailureResult("Nenhum exame fornecido", 400);

            var groupedByMedicalRecord = data.GroupBy(d => d.MedicalRecordId);

            foreach (var group in groupedByMedicalRecord)
            {
                var medicalRecordId = group.Key;
                var medicalRecord = await medicalRecordGateway.FindById(medicalRecordId);
                if (medicalRecord is null)
                    return ResultPattern<string>.FailureResult($"Erro ao adicionar exames, ficha médica {medicalRecordId} não encontrada", 404);

                medicalRecord.PatientExams ??= new List<PatientExamsEntity>();

                foreach (var examDto in group)
                {
                    var exam = PatientExamsFactory.CreatePatientExamsEntity(examDto);
                    exam.MedicalRecord = medicalRecord;
                    medicalRecord.PatientExams.Add(exam);
                }

                await medicalRecordGateway.Save(medicalRecord);
            }

            return ResultPattern<string>.SuccessResult();
        }
    }
}

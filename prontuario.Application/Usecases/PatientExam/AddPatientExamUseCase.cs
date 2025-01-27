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
        public async Task<ResultPattern<string>> Execute(CreatePatientExamDTO data)
        {
            var medicalRecord = await medicalRecordGateway.GetById(data.MedicalRecordId);
            if (medicalRecord is null)
                return ResultPattern<string>.FailureResult("Erro ao adicionar exame, ficha medica não encontrada", 404);

            // Criar a entidade de exame do paciente
            var exam = PatientExamsFactory.CreatePatientExamsEntity(data);
            exam.MedicalRecord = medicalRecord;

            // Inicializar a lista se for nula
            medicalRecord.PatientExams ??= new List<PatientExamsEntity>();

            // Adicionar o exame à coleção
            medicalRecord.PatientExams.Add(exam);

            // Salvar as alterações no banco
            await medicalRecordGateway.Save(medicalRecord);

            return ResultPattern<string>.SuccessResult();
        }
    }
}

using prontuario.Application.Gateways;
using prontuario.Domain.Dtos.PatientExam;
using prontuario.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Usecases.PatientExam
{
    public class FinalizePatientExamUseCase(IPatientExamGateway patientExamGateway, IServiceGateway serviceGateway)
    {
        public async Task<ResultPattern<string>> Execute(FinalizePatientExamDTO data)
        {
            var patientExam = await patientExamGateway.GetById(data.PatientExamId);
            if (patientExam is null)
                return ResultPattern<string>.FailureResult("Erro ao finalizar exame, exame não encontrado", 404);

            if (patientExam.ExecutionDate.HasValue)
                return ResultPattern<string>.FailureResult("Erro ao finalizar exame, exame já finalizado", 400);

            patientExam.FinalizeExam(data.ExecutionDate);

            await patientExamGateway.Save(patientExam);

            return ResultPattern<string>.SuccessResult();
        }
    }
}

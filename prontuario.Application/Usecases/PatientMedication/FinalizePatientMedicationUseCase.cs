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
    public class FinalizePatientMedicationUseCase(IPatientMedicationGateway patientmedicationGateway, IServiceGateway serviceGateway)
    {
        public async Task<ResultPattern<string>> Execute(FinalizePatientMedicationDTO data)
        {
            var patientMedication = await patientmedicationGateway.GetById(data.PatientMedicationId);
            if (patientMedication is null)
                return ResultPattern<string>.FailureResult("Erro ao finalizar medicação, medicação não encontrada", 404);

            if (patientMedication.ExecutionDate.HasValue)
                return ResultPattern<string>.FailureResult("Erro ao finalizar medicação, medicação já finalizada", 400);

            patientMedication.FinalizeMedication(data.ExecutionDate);

            await patientmedicationGateway.Save(patientMedication);

            return ResultPattern<string>.SuccessResult();
        }
    }
}

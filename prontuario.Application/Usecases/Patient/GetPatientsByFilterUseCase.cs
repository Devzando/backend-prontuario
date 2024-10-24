using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Usecases.Patient
{
    public class GetPatientsByFilterUseCase
    {
        private readonly IGatewayPatient _gatewayPatient;

        public GetPatientsByFilterUseCase(IGatewayPatient gatewayPatient)
        {
            _gatewayPatient = gatewayPatient;
        }

        public async Task<ResultPattern<PatientEntity>> Execute(string filter)
        {
            var result = await _gatewayPatient.GetByFilter(filter);
            return result != null 
                ? ResultPattern<PatientEntity>.SuccessResult(result) 
                : ResultPattern<PatientEntity>.FailureResult("Paciente não encontrado!", 404);
        }
    }
}

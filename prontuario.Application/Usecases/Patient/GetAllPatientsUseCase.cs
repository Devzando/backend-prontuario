using prontuario.Application.Gateways;
using prontuario.Domain.Entities;
using prontuario.Domain.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prontuario.Domain.Entities.Patient;

namespace prontuario.Application.Usecases.Patient
{
    public class GetAllPatientsUseCase
    {
        private readonly IGatewayPatient _gatewayPatient;

        public GetAllPatientsUseCase(IGatewayPatient gatewayPatient)
        {
            _gatewayPatient = gatewayPatient;
        }

        public async Task<ResultPattern<List<PatientEntity>>> Execute()
        {
            var result = await _gatewayPatient.GetAll();
            return ResultPattern<List<PatientEntity>>.SuccessResult(result);
        }
    }
}

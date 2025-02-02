using prontuario.Domain.Entities.PatientExams;
using prontuario.Domain.Entities.PatientMedication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Gateways
{
    public interface IPatientMedicationGateway
    {
        Task<PatientMedicationEntity?> GetById(long id);
        Task Save(PatientMedicationEntity patientExam);
    }
}

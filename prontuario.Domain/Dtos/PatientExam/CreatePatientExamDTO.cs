using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Domain.Dtos.PatientExam
{
    public record CreatePatientExamDTO(
        DateTime PrescriptionDate,
        DateTime? ExecutionDate,
        string Description,
        long MedicalRecordId
    );
}

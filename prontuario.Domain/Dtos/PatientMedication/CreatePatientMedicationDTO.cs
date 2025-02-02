using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Domain.Dtos.PatientMedication
{
    public record CreatePatientMedicationDTO(
            DateTime PrescriptionDate,
            DateTime? ExecutionDate,
            string Description,
            long MedicalRecordId
    );
}

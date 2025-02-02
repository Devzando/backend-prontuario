using prontuario.Domain.Entities.PatientExams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Domain.Entities.PatientMedication
{
    public class PatientMedicationEntityBuilder
    {
        private long _id;
        private DateTime _prescriptionDate;
        private DateTime? _executionDate;
        private string _description = string.Empty;
        private long _medicalRecordId;

        public PatientMedicationEntityBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public PatientMedicationEntityBuilder WithPrescriptionDate(DateTime prescriptionDate)
        {
            _prescriptionDate = prescriptionDate;
            return this;
        }

        public PatientMedicationEntityBuilder WithExecutionDate(DateTime? executionDate)
        {
            _executionDate = executionDate;
            return this;
        }

        public PatientMedicationEntityBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public PatientMedicationEntityBuilder WithMedicalRecordId(long medicalRecordId)
        {
            _medicalRecordId = medicalRecordId;
            return this;
        }

        public PatientMedicationEntity Build()
        {
            return new PatientMedicationEntity(_id, _prescriptionDate, _executionDate, _description, _medicalRecordId);
        }
    }
}

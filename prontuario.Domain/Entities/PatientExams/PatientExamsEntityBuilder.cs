using prontuario.Domain.Entities.MedicalRecord;

namespace prontuario.Domain.Entities.PatientExams
{
    public class PatientExamsEntityBuilder
    {
        private long _id;
        private DateTime _prescriptionDate;
        private DateTime? _executionDate;
        private string _description = string.Empty;
        private long _medicalRecordId;

        public PatientExamsEntityBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public PatientExamsEntityBuilder WithPrescriptionDate(DateTime prescriptionDate)
        {
            _prescriptionDate = prescriptionDate;
            return this;
        }

        public PatientExamsEntityBuilder WithExecutionDate(DateTime? executionDate)
        {
            _executionDate = executionDate;
            return this;
        }

        public PatientExamsEntityBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public PatientExamsEntityBuilder WithMedicalRecordId(long medicalRecordId)
        {
            _medicalRecordId = medicalRecordId;
            return this;
        }

        public PatientExamsEntity Build()
        {
            return new PatientExamsEntity(_id, _prescriptionDate, _executionDate, _description, _medicalRecordId);
        }
    }

}

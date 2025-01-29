namespace prontuario.WebApi.ResponseModels.PatientExams
{
    public class PatientExamsResponseBuilder
    {
        private long _id;
        private DateTime _prescriptionDate;
        private DateTime? _executionDate;
        private string? _description;

        public PatientExamsResponseBuilder WithId(long id)
        {
            _id = id;
            return this;
        }

        public PatientExamsResponseBuilder WithPrescriptionDate(DateTime prescriptionDate)
        {
            _prescriptionDate = prescriptionDate;
            return this;
        }

        public PatientExamsResponseBuilder WithExecutionDate(DateTime? executionDate)
        {
            _executionDate = executionDate;
            return this;
        }

        public PatientExamsResponseBuilder WithDescription(string? description)
        {
            _description = description;
            return this;
        }

        public PatientExamsResponse Build()
        {
            return new PatientExamsResponse(
                _id,
                _prescriptionDate,
                _executionDate,
                _description
            );
        }
    }

}

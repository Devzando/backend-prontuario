namespace prontuario.WebApi.ResponseModels.PatientExams
{
    public record PatientExamsResponse(long Id, DateTime PrescriptionDate, DateTime? ExecutionDate);
}

namespace prontuario.WebApi.ResponseModels.PatientMedications
{
    public record PatientMedicationResponse(long Id, DateTime PrescriptionDate, DateTime? ExecutionDate, string? Description);
}

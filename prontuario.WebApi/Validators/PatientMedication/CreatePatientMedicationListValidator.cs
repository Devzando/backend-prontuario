using FluentValidation;
using prontuario.Domain.Dtos.PatientMedication;

namespace prontuario.WebApi.Validators.PatientMedication
{
    public class CreatePatientMedicationListValidator : AbstractValidator<List<CreatePatientMedicationDTO>>
    {
        public CreatePatientMedicationListValidator()
        {
            RuleForEach(x => x).SetValidator(new CreatePatientMedicationValidator());
        }
    }
}

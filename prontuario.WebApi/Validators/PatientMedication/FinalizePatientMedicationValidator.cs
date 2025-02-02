using FluentValidation;
using prontuario.Domain.Dtos.PatientExam;

namespace prontuario.WebApi.Validators.PatientMedication
{
    public class FinalizePatientMedicationValidator : AbstractValidator<FinalizePatientMedicationDTO>
    {
        public FinalizePatientMedicationValidator()
        {
            RuleFor(x => x.PatientMedicationId)
                .GreaterThan(0).WithMessage("O ID da medicação deve ser maior que zero!");

            RuleFor(x => x.ExecutionDate)
                .NotEmpty().WithMessage("A data de administração é obrigatória!")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de administração não pode ser no futuro!");
        }
    }
}

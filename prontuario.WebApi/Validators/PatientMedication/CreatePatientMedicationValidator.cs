using FluentValidation;
using prontuario.Domain.Dtos.PatientMedication;

namespace prontuario.WebApi.Validators.PatientMedication
{
    public class CreatePatientMedicationValidator : AbstractValidator<CreatePatientMedicationDTO>
    {
        public CreatePatientMedicationValidator()
        {
            RuleFor(x => x.PrescriptionDate)
                .NotEmpty().WithMessage("A data de prescrição é obrigatória!")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de prescrição não pode ser no futuro!");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A descrição é obrigatória!")
                .MinimumLength(2).WithMessage("A descrição deve ter pelo menos 2 caracteres.")
                .MaximumLength(200).WithMessage("A descrição deve ter no máximo 200 caracteres.");

            RuleFor(x => x.MedicalRecordId)
                .GreaterThan(0).WithMessage("O ID do prontuário deve ser maior que zero!");
        }
    }
}

using FluentValidation;
using prontuario.Domain.Dtos.PatientExam;

namespace prontuario.WebApi.Validators.PatientExam
{
    public class CreatePatientExamValidator : AbstractValidator<CreatePatientExamDTO>
    {
        public CreatePatientExamValidator()
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

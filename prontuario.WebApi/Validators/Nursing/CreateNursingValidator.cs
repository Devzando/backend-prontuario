using FluentValidation;
using prontuario.Domain.Dtos.Nursing;

namespace prontuario.WebApi.Validators.Nursing
{
    public class CreateNursingNoteValidator : AbstractValidator<CreateNursingNoteDTO>
    {
        public CreateNursingNoteValidator() 
        {
            RuleFor(x => x.NursingNote)
                .NotEmpty().WithMessage("Anotação de enfermagem obrigatória!")
                .MinimumLength(2).WithMessage("Anotação deve ter pelo menos 2 caracteres")
                .MaximumLength(200).WithMessage("Anotação deve ter no máximo 200 caracteres");

            RuleFor(x => x.PatientEntity)
                .NotEmpty().WithMessage("Você deve informar para qual o paciente é anotação!");
        }
    }
}

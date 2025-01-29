using FluentValidation;
using prontuario.Domain.Dtos.Notes;

namespace prontuario.WebApi.Validators.Notes
{
    public class CreateNoteValidator : AbstractValidator<CreateNotesDTO>
    {
        public CreateNoteValidator()
        {
            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("Id do paciente é obrigatório");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("Id do usuário é obrigatório");

            RuleFor(x => x.Description)
                .NotNull().WithMessage("Anotação não pode ser nula")
                .NotEmpty().WithMessage("Anotação é obrigatória")
                .MinimumLength(2).WithMessage("Anotação deve ter pelo menos 2 caracteres")
                .MaximumLength(2000).WithMessage("Anotação deve ter no máximo 2000 caracteres");
        }
    }
}

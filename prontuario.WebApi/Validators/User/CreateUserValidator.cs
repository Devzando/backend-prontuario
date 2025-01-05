using FluentValidation;
using prontuario.WebApi.RequestModels.User;

namespace prontuario.WebApi.Validators.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(2).WithMessage("Nome deve ter pelo menos 2 caracteres");

            RuleFor(x => x.Email)
                .NotNull().WithMessage("O campo Email não pode ser nulo.")
                .NotEmpty().WithMessage("O campo Email é obrigatório.")
                .EmailAddress().WithMessage("O campo Email deve conter um endereço de e-mail válido.");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("O campo Password não pode ser nulo.")
                .NotEmpty().WithMessage("O campo Password é obrigatório.")
                .MinimumLength(6).WithMessage("O campo Password deve ter no mínimo 6 caracteres.")
                .MaximumLength(50).WithMessage("O campo Password deve ter no máximo 50 caracteres.");

            RuleFor(x => x.FirstAccess)
                .NotNull().WithMessage("O campo FirstAccess não pode ser nulo.")
                .NotEmpty().WithMessage("O campo FirstAccess é obrigatório.");

            RuleFor(x => x.Active)
                .NotNull().WithMessage("O campo Active não pode ser nulo.")
                .NotEmpty().WithMessage("O campo Active é obrigatório.");

            RuleFor(x => x.Profile.Role)
                .NotNull().WithMessage("O campo Role não pode ser nulo.")
                .NotEmpty().WithMessage("O campo Role é obrigatório.")
                .Must(role => role == "ADMIN" || role == "RECEPTIONTEAM" || role == "HEALTHTEAM" || role == "INTITUATIONMANAGEMENT")
                .WithMessage("O campo Role deve ser ADMIN, RECEPTIONTEAM, HEALTHTEAM ou INTITUATIONMANAGEMENT");
        }
    }
}

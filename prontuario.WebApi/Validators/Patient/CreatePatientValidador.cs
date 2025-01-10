using FluentValidation;
using prontuario.Domain.Dtos.Patient;

namespace prontuario.WebApi.Validators.Patient
{
    public class CreatePatientValidador : AbstractValidator<CreatePatientDTO>
    {
        public CreatePatientValidador() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MinimumLength(2).WithMessage("Nome deve ter pelo menos 2 caracteres");

            RuleFor(x => x.BirthDate)
                .NotEmpty().WithMessage("Data de nascimento é obrigatória")
                .Must(date => date <= DateTime.Today).WithMessage("Data de nascimento não pode ser no futuro");

            RuleFor(x => x.Sus)
                .NotEmpty().WithMessage("SUS é obrigatório")
                .Matches(@"^\d{15}$").WithMessage("SUS deve ter 15 dígitos numéricos");

            RuleFor(x => x.Cpf)
                .NotEmpty().WithMessage("CPF é obrigatório")
                .Matches(@"^\d{11}$").WithMessage("CPF deve ter 11 dígitos numéricos");

            RuleFor(x => x.Rg)
                .NotEmpty().WithMessage("RG é obrigatório")
                .Length(5, 14).WithMessage("RG deve ter entre 5 e 14 caracteres");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Número de telefone é obrigatório")
                .Matches(@"^\d{10,11}$").WithMessage("Telefone deve ter 10 ou 11 dígitos numéricos");

            RuleFor(x => x.Address.Cep)
                .NotEmpty().WithMessage("CEP é obrigatório")
                .Matches(@"^\d{8}$").WithMessage("CEP deve ter 8 dígitos numéricos");

            RuleFor(x => x.Address.Street)
                .NotEmpty().WithMessage("Rua é obrigatória");

            RuleFor(x => x.Address.City)
                .NotEmpty().WithMessage("Cidade é obrigatória");

            RuleFor(x => x.Address.Number)
                .NotEmpty().WithMessage("Número da residência é obrigatório");

            RuleFor(x => x.EmergencyContactDetails.Name)
                .NotEmpty().WithMessage("Nome do contato de emergência é obrigatório")
                .MinimumLength(2).WithMessage("Nome do contato de emergência deve ter pelo menos 2 caracteres");

            RuleFor(x => x.EmergencyContactDetails.Phone)
                .NotEmpty().WithMessage("Telefone do contato de emergência é obrigatório")
                .Matches(@"^\d{10,11}$").WithMessage("Telefone do contato de emergência deve ter 10 ou 11 dígitos numéricos");

            RuleFor(x => x.EmergencyContactDetails.Relationship)
                .NotEmpty().WithMessage("Relação com o contato de emergência é obrigatória")
                .MinimumLength(2).WithMessage("Relação com o contato de emergência deve ter pelo menos 2 caracteres");
        }
    }
}

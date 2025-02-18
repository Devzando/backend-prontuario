using FluentValidation;
using prontuario.Domain.Dtos.MedicalCare;

namespace prontuario.WebApi.Validators.MedicalCare
{
    public class CreateMedicalCareValidar : AbstractValidator<CreateMedicalCareDTO>
    {
        public CreateMedicalCareValidar()
        {
            RuleFor(x => x.Ritmo)
                .MinimumLength(5).WithMessage("Ritmo cardíaco deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Ritmo cardíaco deve ter no máximo 100 caracteres");

            RuleFor(x => x.Pulso)
                .MinimumLength(5).WithMessage("Pulso deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Pulso deve ter no máximo 100 caracteres");

            RuleFor(x => x.Bulhas)
                .MinimumLength(5).WithMessage("Bulhas deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Bulhas deve ter no máximo 100 caracteres");
            
            RuleFor(x => x.NivelDeConsciencia)
                .MinimumLength(5).WithMessage("Nível de consciência deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Nível de consciência deve ter no máximo 100 caracteres");

            RuleFor(x => x.RespostaMotora)
                .MinimumLength(5).WithMessage("Resposta motora deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Resposta motora deve ter no máximo 100 caracteres");

            RuleFor(x => x.Fala)
                .MinimumLength(5).WithMessage("Fala deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Fala deve ter no máximo 100 caracteres");

            RuleFor(x => x.Pupila)
                .MinimumLength(5).WithMessage("Pupila deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Pupila deve ter no máximo 100 caracteres");
            
            RuleFor(x => x.BreathingPattern)
                .MinimumLength(5).WithMessage("Padrão de respiração deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Padrão de respiração deve ter no máximo 100 caracteres");

            RuleFor(x => x.Pulmonar)
                .MinimumLength(5).WithMessage("Pulmonar deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Pulmonar deve ter no máximo 100 caracteres");

            RuleFor(x => x.ColoracaoPele)
                .MinimumLength(5).WithMessage("Coloração da pele deve ter pelo menos 5 caracteres")
                .MaximumLength(100).WithMessage("Coloração da pele deve ter no máximo 100 caracteres");
            
            RuleFor(x => x.serviceId)
                .NotNull().WithMessage("O id do service não deve ser nulo")
                .NotEmpty().WithMessage("O id do service não deve ser vazio");
        }
    }
}

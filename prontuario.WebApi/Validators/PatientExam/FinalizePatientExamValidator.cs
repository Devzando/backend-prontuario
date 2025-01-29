using FluentValidation;
using prontuario.Domain.Dtos.PatientExam;

namespace prontuario.WebApi.Validators.PatientExam
{
 
    public class FinalizePatientExamValidator : AbstractValidator<FinalizePatientExamDTO>
    {
        public FinalizePatientExamValidator()
        {
            RuleFor(x => x.PatientExamId)
                .GreaterThan(0).WithMessage("O ID do exame deve ser maior que zero!");

            RuleFor(x => x.ExecutionDate)
                .NotEmpty().WithMessage("A data de execução é obrigatória!")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de execução não pode ser no futuro!");
        }
    }

}

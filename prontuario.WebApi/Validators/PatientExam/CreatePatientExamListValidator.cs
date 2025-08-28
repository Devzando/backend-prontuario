using FluentValidation;
using prontuario.Domain.Dtos.PatientExam;

namespace prontuario.WebApi.Validators.PatientExam
{
    public class CreatePatientExamListValidator : AbstractValidator<List<CreatePatientExamDTO>>
    {
        public CreatePatientExamListValidator()
        {
            RuleForEach(x => x).SetValidator(new CreatePatientExamValidator());
        }
    }
}

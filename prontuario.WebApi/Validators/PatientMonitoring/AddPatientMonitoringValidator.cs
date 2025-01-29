using FluentValidation;
using prontuario.Domain.Dtos.PatientMonitoring;

namespace prontuario.WebApi.Validators.PatientMonitoring
{
    public class AddPatientMonitoringValidator : AbstractValidator<CreatePatientMonitoringDTO>
    {
        public AddPatientMonitoringValidator()
        {
            RuleFor(x => x.MedicalRecordId)
                .GreaterThan(0).WithMessage("O ID do prontuário deve ser maior que zero!");

            //RuleFor(x => x.BloodPressure)
            //    .NotEmpty().WithMessage("A pressão arterial é obrigatória!")
            //    .Matches(@"^\d{1,3}/\d{1,3}$").WithMessage("A pressão arterial deve estar no formato '120/80'.");

            //RuleFor(x => x.Glucose)
            //    .NotEmpty().WithMessage("O nível de glicose é obrigatório!")
            //    .Matches(@"^\d+(\.\d+)?$").WithMessage("O nível de glicose deve ser numérico.");

            //RuleFor(x => x.Temperature)
            //    .NotEmpty().WithMessage("A temperatura é obrigatória!")
            //    .Matches(@"^\d+(\.\d+)?$").WithMessage("A temperatura deve ser numérica.")
            //    .Must(temp => double.TryParse(temp, out var value) && value > 0 && value < 50)
            //    .WithMessage("A temperatura deve ser um valor válido entre 0 e 50.");

            //RuleFor(x => x.Saturation)
            //    .NotEmpty().WithMessage("A saturação é obrigatória!")
            //    .Matches(@"^\d{1,3}%?$").WithMessage("A saturação deve ser numérica e pode incluir '%'.");

            //RuleFor(x => x.RespiratoryRate)
            //    .NotEmpty().WithMessage("A frequência respiratória é obrigatória!")
            //    .Matches(@"^\d+$").WithMessage("A frequência respiratória deve ser um valor numérico.");
        }
    }
}

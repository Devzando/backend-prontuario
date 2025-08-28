using prontuario.Domain.Dtos.Anamnese;
using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;

namespace prontuario.Application.Factories;

public class AnamneseFactory
{
    public static AnamneseEntity CreateAnamneseEntity(CreateAnamneseDTO data)
    {
        return new AnamneseEntityBuilder()
            .WithBloodPressure(data.BloodPressure)
            .WithGlucose(data.Glucose)
            .WithTemperature(data.Temperature)
            .WithRespiratoryRate(data.RespiratoryRate)
            .WithBloodType(data.BloodType)
            .WithWeight(data.Weight)
            .WithHeartRate(data.HeartRate)
            .WithSaturation(data.Saturation)
            .WithHeight(data.Height)
            .WithAntecPathological(data.AntecPathological)
            .WithNecesPsicobio(data.NecesPsicobio)
            .WithDiabetes(data.Diabetes)
            .WithMedicationsInUse(data.MedicationsInUse)
            .WithUseOfProthesis(data.UseOfProthesis)
            .WithAllergies(data.Allergies)
            .WithAllergiesType(data.AllergiesType)
            .WithAntecPathologicalType(data.AntecPathologicalType)
            .WithMedicationInUseType(data.MedicationInUseType)
            .WithMedicalHypothesis(data.MedicalHypothesis)
            .WithPreviousSurgeries(data.PreviousSurgeries)
            .WithSignsAndSymptoms(data.SignsAndSymptoms)
            .WithClassificationStatus(new ClassificationStatus(data.ClassificationStatus))
            .Build();
    }
}
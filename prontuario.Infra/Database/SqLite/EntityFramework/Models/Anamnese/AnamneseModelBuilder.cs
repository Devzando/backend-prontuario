namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Anamnese;

public class AnamneseModelBuilder
{
    private long? _id;
    private string _bloodPressure = string.Empty;
    private string _glucose = string.Empty;
    private string _temperature = string.Empty;
    private string _respiratoryRate = string.Empty;
    private string _bloodType = string.Empty;
    private string _weight = string.Empty;
    private string _heartRate = string.Empty;
    private string _saturation = string.Empty;
    private string _height = string.Empty;
    private bool _antecPathological = false;
    private bool _necesPsicobio = false;
    private bool _diabetes = false;
    private bool _medicationsInUse = false;
    private bool _useOfProthesis = false;
    private bool _allergies = false;
    private string _allergiesType = string.Empty;
    private string _antecPathologicalType = string.Empty;
    private string _medicationInUseType = string.Empty;
    private string _medicalHypothesis = string.Empty;
    private string _previousSurgeries = string.Empty;
    private string _classificationStatus = string.Empty;

    public AnamneseModelBuilder WithId(long? id)
    {
        _id = id;
        return this;
    }

    public AnamneseModelBuilder WithBloodPressure(string bloodPressure)
    {
        _bloodPressure = bloodPressure;
        return this;
    }

    public AnamneseModelBuilder WithGlucose(string glucose)
    {
        _glucose = glucose;
        return this;
    }

    public AnamneseModelBuilder WithTemperature(string temperature)
    {
        _temperature = temperature;
        return this;
    }

    public AnamneseModelBuilder WithRespiratoryRate(string respiratoryRate)
    {
        _respiratoryRate = respiratoryRate;
        return this;
    }

    public AnamneseModelBuilder WithBloodType(string bloodType)
    {
        _bloodType = bloodType;
        return this;
    }

    public AnamneseModelBuilder WithWeight(string weight)
    {
        _weight = weight;
        return this;
    }

    public AnamneseModelBuilder WithHeartRate(string heartRate)
    {
        _heartRate = heartRate;
        return this;
    }

    public AnamneseModelBuilder WithSaturation(string saturation)
    {
        _saturation = saturation;
        return this;
    }

    public AnamneseModelBuilder WithHeight(string height)
    {
        _height = height;
        return this;
    }

    public AnamneseModelBuilder WithAntecPathological(bool antecPathological)
    {
        _antecPathological = antecPathological;
        return this;
    }

    public AnamneseModelBuilder WithNecesPsicobio(bool necesPsicobio)
    {
        _necesPsicobio = necesPsicobio;
        return this;
    }

    public AnamneseModelBuilder WithDiabetes(bool diabetes)
    {
        _diabetes = diabetes;
        return this;
    }

    public AnamneseModelBuilder WithMedicationsInUse(bool medicationsInUse)
    {
        _medicationsInUse = medicationsInUse;
        return this;
    }

    public AnamneseModelBuilder WithUseOfProthesis(bool useOfProthesis)
    {
        _useOfProthesis = useOfProthesis;
        return this;
    }

    public AnamneseModelBuilder WithAllergies(bool allergies)
    {
        _allergies = allergies;
        return this;
    }

    public AnamneseModelBuilder WithAllergiesType(string allergiesType)
    {
        _allergiesType = allergiesType;
        return this;
    }

    public AnamneseModelBuilder WithAntecPathologicalType(string antecPathologicalType)
    {
        _antecPathologicalType = antecPathologicalType;
        return this;
    }

    public AnamneseModelBuilder WithMedicationInUseType(string medicationInUseType)
    {
        _medicationInUseType = medicationInUseType;
        return this;
    }

    public AnamneseModelBuilder WithMedicalHypothesis(string medicalHypothesis)
    {
        _medicalHypothesis = medicalHypothesis;
        return this;
    }

    public AnamneseModelBuilder WithPreviousSurgeries(string previousSurgeries)
    {
        _previousSurgeries = previousSurgeries;
        return this;
    }

    public AnamneseModelBuilder WithClassificationStatus(string classificationStatus)
    {
        _classificationStatus = classificationStatus;
        return this;
    }

    public AnamneseModel Build()
    {
        return new AnamneseModel(
            _id,
            _bloodPressure,
            _glucose,
            _temperature,
            _respiratoryRate,
            _bloodType,
            _weight,
            _heartRate,
            _saturation,
            _height,
            _antecPathological,
            _necesPsicobio,
            _diabetes,
            _medicationsInUse,
            _useOfProthesis,
            _allergies,
            _allergiesType,
            _antecPathologicalType,
            _medicationInUseType,
            _medicalHypothesis,
            _previousSurgeries,
            _classificationStatus
        );
    }
}
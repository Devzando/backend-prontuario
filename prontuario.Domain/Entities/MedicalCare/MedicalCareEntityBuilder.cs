using prontuario.Domain.Entities.Patient;
using prontuario.Domain.ValuesObjects;


namespace prontuario.Domain.Entities.MedicalCare;

public class MedicalCareEntityBuilder
{
    private long _id;
    private string? _medicalHypothesis;
    private string? _examPrescription;
    private string? _medicalPrescription;
    private long _patientId;
    private BreathingPatternStatus _breathingPattern = null!;
    private PulmonarStatus _pulmonar = null!;
    private ColoracaoPeleStatus _coloracaoPele = null!;
    private PupilaStatus _pupila = null!;
    private FalaStatus _fala = null!;
    private NivelDeConscienciaStatus _nivelDeConsciencia = null!;
    private RespostaMotoraStatus _respostaMotora = null!;
    private BulhasStatus _bulhas = null!;
    private RitmoStatus _ritmo = null!;
    private PulsoStatus _pulso = null!;

    public MedicalCareEntityBuilder WithId(long id){
        _id = id;
        return this;
    }

    public MedicalCareEntityBuilder WithMedicalHypothesis(string? medicalHypothesis) 
    {
        _medicalHypothesis = medicalHypothesis;
        return this;
    }

    public MedicalCareEntityBuilder WithExamPrescription(string? examPrescription) 
    {
        _examPrescription = examPrescription;
        return this;
    }

    public MedicalCareEntityBuilder WithMedicalPrescription(string? medicalPrescription) 
    {
        _medicalPrescription = medicalPrescription;
        return this;
    }

    public MedicalCareEntityBuilder WithPatientId(long patientId)
    {
        _patientId = patientId;
        return this;
    }

    public MedicalCareEntity Build() 
    {
        return new MedicalCareEntity(_id, 
            _medicalHypothesis, 
            _examPrescription, 
            _medicalPrescription, 
            _patientId, 
            _breathingPattern, 
            _pulmonar, 
            _coloracaoPele,
            _pupila,
            _fala,
            _nivelDeConsciencia,
            _respostaMotora,
            _bulhas,
            _ritmo,
            _pulso
        );
    }
}
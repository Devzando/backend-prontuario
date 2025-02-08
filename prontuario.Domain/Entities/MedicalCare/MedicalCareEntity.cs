using prontuario.Domain.ValuesObjects;

namespace prontuario.Domain.Entities.MedicalCare;

public class MedicalCareEntity
{
    public long Id { get; private set; }
    public string? ExamPrescription { get; private set; }
    public string? MedicalHypothesis { get; private set; }
    public string? MedicalPrescription { get; private set; }
    public long PatientId { get; private set; }
    public BreathingPatternStatus BreathingPattern { get; set; } = null!;
    public PulmonarStatus Pulmonar { get; set; } = null!;
    public ColoracaoPeleStatus ColoracaoPele { get; set; } = null!;
    public PupilaStatus Pupila { get; set; } = null!;
    public FalaStatus Fala { get; set; } = null!;
    public NivelDeConscienciaStatus NivelDeConsciencia { get; set; } = null!;
    public RespostaMotoraStatus RespostaMotora { get; set; } = null!;
    public BulhasStatus Bulhas { get; set; } = null!;
    public RitmoStatus Ritmo { get; set; } = null!;
    public PulsoStatus Pulso { get; set; } = null!;


    
    public MedicalCareEntity() { }
    
    public MedicalCareEntity(long id, 
        string? examPrescription, 
        string? medicalHypothesis, 
        string? medicalPrescription, 
        long patient,
        BreathingPatternStatus breathingPattern,
        PulmonarStatus pulmonar,
        ColoracaoPeleStatus coloracaoPele,
        PupilaStatus pupila,
        FalaStatus fala,
        NivelDeConscienciaStatus nivelDeConsciencia,
        RespostaMotoraStatus respostaMotora,
        BulhasStatus bulhas,
        RitmoStatus ritmo,
        PulsoStatus pulso
        )
    {
        this.Id = id;
        this.ExamPrescription = examPrescription;
        this.MedicalHypothesis = medicalHypothesis;
        this.MedicalPrescription = medicalPrescription;
        this.PatientId = patient;
        this.BreathingPattern = breathingPattern;
        this.Pulmonar = pulmonar;
        this.ColoracaoPele = coloracaoPele;
        this.Pupila = pupila;
        this.Fala = fala;
        this.NivelDeConsciencia = nivelDeConsciencia;
        this.RespostaMotora = respostaMotora;
        this.Bulhas = bulhas;
        this.Ritmo = ritmo;
        this.Pulso = pulso;

    }
}
using prontuario.Domain.Entities.Patient;
using prontuario.Domain.Entities.Service;
using prontuario.Domain.ValuesObjects;


namespace prontuario.Domain.Entities.MedicalCare;

public class MedicalCareEntityBuilder
{
    private long _id;
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
    private ServiceEntity _service = null!;

    public MedicalCareEntityBuilder WithId(long id){
        _id = id;
        return this;
    }

    public MedicalCareEntityBuilder WithBreathingPattern(BreathingPatternStatus breathingPattern)
    {
        _breathingPattern = breathingPattern;
        return this;
    }

    public MedicalCareEntityBuilder WithPulmonarStatus(PulmonarStatus pulmonar)
    {
        _pulmonar = pulmonar;
         return this;
    }

    public MedicalCareEntityBuilder WithColoracaoPeleStatus(ColoracaoPeleStatus coloracaoPele)
    {
        _coloracaoPele = coloracaoPele;
        return this;
    }

    public MedicalCareEntityBuilder WithPupilaStatus(PupilaStatus pupila)
    {
        _pupila = pupila;
        return this;
    }

    public MedicalCareEntityBuilder WithFalaStatus(FalaStatus fala)
    {
        _fala = fala;
        return this;
    }

    public MedicalCareEntityBuilder WithNivelDeConscienciaStatus(NivelDeConscienciaStatus nivelDeConsciencia)
    {
        _nivelDeConsciencia = nivelDeConsciencia;
        return this;
    }

    public MedicalCareEntityBuilder WithRespostaMotoraStatus(RespostaMotoraStatus respostaMotora)
    {
        _respostaMotora = respostaMotora;
        return this;
    }

    public MedicalCareEntityBuilder WithBulhasStatus(BulhasStatus bulhas)
    {
        _bulhas = bulhas;
        return this;
    }

    public MedicalCareEntityBuilder WithRitmoStatus(RitmoStatus ritmo)
    {
        _ritmo = ritmo;
        return this;
    }

    public MedicalCareEntityBuilder WithPulsoStatus(PulsoStatus pulso)
    {
        _pulso = pulso;
        return this;
    }

    public MedicalCareEntityBuilder WithServiceEntity(ServiceEntity service)
    {
        _service = service;
        return this;
    }
    
    public MedicalCareEntity Build() 
    {
        return new MedicalCareEntity(_id, 
            _breathingPattern, 
            _pulmonar, 
            _coloracaoPele,
            _pupila,
            _fala,
            _nivelDeConsciencia,
            _respostaMotora,
            _bulhas,
            _ritmo,
            _pulso,
            _service
        );
    }
}
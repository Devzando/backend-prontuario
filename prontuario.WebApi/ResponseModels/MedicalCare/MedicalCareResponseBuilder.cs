using prontuario.WebApi.ResponseModels.Anamnese;
using prontuario.WebApi.ResponseModels.PatientExams;
using prontuario.WebApi.ResponseModels.PatientMedications;
using prontuario.WebApi.ResponseModels.PatientMonitoring;

namespace prontuario.WebApi.ResponseModels.MedicalCare;

public class MedicalCareResponseBuilder
{
    long _id;
    string? _breathingPattern;
    string? _pulmonar;
    string? _coloracaoPele;
    string? _pupila;
    string? _fala;
    string? _nivelDeConsciencia;
    string? _respostaMotora;
    string? _bulhas;
    string? _ritmo;
    string? _pulso;
    

    public MedicalCareResponseBuilder WithId(long id)
    {
        _id = id;
        return this;
    }

    public MedicalCareResponseBuilder WithBreathingPattern(string? breathingPattern)
    {
        _breathingPattern = breathingPattern;
        return this;
    }

    public MedicalCareResponseBuilder WithPulmonar(string? pulmonar)
    {
        _pulmonar = pulmonar;
        return this;
    }

    public MedicalCareResponseBuilder WithColoracaoPele(string? coloracaoPele)
    {
        _coloracaoPele = coloracaoPele;
        return this;
    }

    public MedicalCareResponseBuilder WithPupila(string? pupila)
    {
        _pupila = pupila;
        return this;
    }

    public MedicalCareResponseBuilder WithFala(string? fala)
    {
        _fala = fala;
        return this;
    }

    public MedicalCareResponseBuilder WithNivelDeConsciencia(string? nivelDeConsciencia)
    {
        _nivelDeConsciencia = nivelDeConsciencia;
        return this;
    }

    public MedicalCareResponseBuilder WithRespostaMotora(string? respostaMotora)
    {
        _respostaMotora = respostaMotora;
        return this;
    }

    public MedicalCareResponseBuilder WithBulhas(string? bulhas)
    {
        _bulhas = bulhas;
        return this;
    }

    public MedicalCareResponseBuilder WithRitmo(string? ritmo)
    {
        _ritmo = ritmo;
        return this;
    }

    public MedicalCareResponseBuilder WithPulso(string? pulso)
    {
        _pulso = pulso;
        return this;
    }


    public MedicalCareResponse Build()
    {
        return new MedicalCareResponse(
            _id,
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
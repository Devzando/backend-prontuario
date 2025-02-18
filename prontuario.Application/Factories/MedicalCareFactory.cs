using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Entities.MedicalCare;
using prontuario.Domain.ValuesObjects;


namespace prontuario.Application.Factories
{
    public class MedicalCareFactory
    {
        public static MedicalCareEntity Create(CreateMedicalCareDTO data)
        {
            return new MedicalCareEntityBuilder()
                .WithBreathingPattern(new BreathingPatternStatus(data.BreathingPattern))
                .WithBulhasStatus(new BulhasStatus(data.Bulhas))
                .WithFalaStatus(new FalaStatus(data.Fala))
                .WithPulmonarStatus(new PulmonarStatus(data.Pulmonar))
                .WithColoracaoPeleStatus(new ColoracaoPeleStatus(data.ColoracaoPele))
                .WithRespostaMotoraStatus(new RespostaMotoraStatus(data.RespostaMotora))
                .WithNivelDeConscienciaStatus(new NivelDeConscienciaStatus(data.NivelDeConsciencia))
                .WithPulsoStatus(new PulsoStatus(data.Pulso))
                .WithPupilaStatus(new PupilaStatus(data.Pupila))
                .WithRitmoStatus(new RitmoStatus(data.Ritmo))
                .Build();
        }
    }
}

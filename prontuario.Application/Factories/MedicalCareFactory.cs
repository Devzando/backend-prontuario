using prontuario.Domain.Dtos.MedicalCare;
using prontuario.Domain.Entities.MedicalCare;
using prontuario.Domain.Enums;
using prontuario.Domain.ValuesObjects;


namespace prontuario.Application.Factories
{
    public class MedicalCareFactory
    {
        public static MedicalCareEntity CreateExamPrescription(CreateExamPrescriptionDTO data)
        {
            return new MedicalCareEntityBuilder()
                .WithExamPrescription(data.ExamPrescription)
                .WithPatientId(data.PatientId)
                .Build();
        }

        public static MedicalCareEntity CreateMedicalHypothesis(CreateMedicalHypothesisDTO data)
        {
            return new MedicalCareEntityBuilder()
                .WithMedicalHypothesis(data.MedicalHypothesis)
                .WithPatientId(data.PatientId)
                .Build();
        }

        public static MedicalCareEntity CreateMedicalPrescription(CreateMedicalPrescriptionDTO data)
        {
            return new MedicalCareEntityBuilder()
                .WithMedicalPrescription(data.MedicalPrescription)
                .WithPatientId(data.PatientId)
                .Build();
        }
        public static MedicalCareEntity CreatePsychobiologicalNeeds(CreatePsychobiologicalNeedsDTO data)
        {
            if(data.BreathingPattern == "EUPNEICO")
            {
                data.MedicalCareEntity.BreathingPattern = new BreathingPatternStatus(BreathingPatternStatusType.EUPNEICO.ToString());
            } else if (data.BreathingPattern == "DISPNEICO") {
                data.MedicalCareEntity.BreathingPattern = new BreathingPatternStatus(BreathingPatternStatusType.DISPNEICO.ToString());
            } else if (data.BreathingPattern == "TAQUIPNEICO") {
                data.MedicalCareEntity.BreathingPattern = new BreathingPatternStatus(BreathingPatternStatusType.TAQUIPNEICO.ToString());
            } else if (data.BreathingPattern == "BRADIPNEICO") {
                data.MedicalCareEntity.BreathingPattern = new BreathingPatternStatus(BreathingPatternStatusType.BRADIPNEICO.ToString());
            } else if (data.BreathingPattern == "APNEIA") {
                data.MedicalCareEntity.BreathingPattern = new BreathingPatternStatus(BreathingPatternStatusType.APNEIA.ToString());
            }

            if(data.Pulmonar == "MURMURIOS_PRESENTES_BILATERAL"){
                data.MedicalCareEntity.Pulmonar = new PulmonarStatus(PulmonarStatusType.MURMURIOS_PRESENTES_BILATERAL.ToString());
            } else if (data.Pulmonar == "RONCOS") {
                data.MedicalCareEntity.Pulmonar = new PulmonarStatus(PulmonarStatusType.RONCOS.ToString());
            } else if (data.Pulmonar == "SIBILOS") {
                data.MedicalCareEntity.Pulmonar = new PulmonarStatus(PulmonarStatusType.SIBILOS.ToString());
            } else if (data.Pulmonar == "CREPTOS") {
                data.MedicalCareEntity.Pulmonar = new PulmonarStatus(PulmonarStatusType.CREPTOS.ToString());
            } else if (data.Pulmonar == "ESTERTORES") {
                data.MedicalCareEntity.Pulmonar = new PulmonarStatus(PulmonarStatusType.ESTERTORES.ToString());
            }

            if(data.ColoracaoPele == "NORMOCORADA"){
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.NORMOCORADA.ToString());
            } else if (data.ColoracaoPele == "HIPORCORADA") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.HIPORCORADA.ToString());
            } else if (data.ColoracaoPele == "PRESENCA_DE_LESAO_POR_PRESSAO") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.PRESENCA_DE_LESAO_POR_PRESSAO.ToString());
            } else if (data.ColoracaoPele == "PRESENCA_DE_MACULAS") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.PRESENCA_DE_MACULAS.ToString());
            } else if (data.ColoracaoPele == "PRESENCA_DE_PETEQUIAS") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.PRESENCA_DE_PETEQUIAS.ToString());
            } else if (data.ColoracaoPele == "PRESENCA_DE_PAPULAS") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.PRESENCA_DE_PAPULAS.ToString());
            } else if (data.ColoracaoPele == "PRESENCA_DE_VESICULAS") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.PRESENCA_DE_VESICULAS.ToString());
            } else if (data.ColoracaoPele == "PRESENCA_DE_PUSTULAS") {
                data.MedicalCareEntity.ColoracaoPele = new ColoracaoPeleStatus(ColoracaoPeleStatusType.PRESENCA_DE_PUSTULAS.ToString());
            }

            return data.MedicalCareEntity;
        }

        public static MedicalCareEntity CreateNeuro(CreateNeuroDTO data)
        {
            if(data.Pupila == "ISOCORICA"){
                data.MedicalCareEntity.Pupila = new PupilaStatus(PupilaStatusType.ISOCORICA.ToString());
            } else if (data.Pupila == "ANISOCORICA") {
                data.MedicalCareEntity.Pupila = new PupilaStatus(PupilaStatusType.ANISOCORICA.ToString());
            } else if (data.Pupila == "MIDRIASE") {
                data.MedicalCareEntity.Pupila = new PupilaStatus(PupilaStatusType.MIDRIASE.ToString());
            } else if (data.Pupila == "MIOTICA") {
                data.MedicalCareEntity.Pupila = new PupilaStatus(PupilaStatusType.MIOTICA.ToString());
            }

            if(data.Fala == "AFASIA"){
                data.MedicalCareEntity.Fala = new FalaStatus(FalaStatusType.AFASIA.ToString());
            } else if (data.Fala == "DISFASIA") {
                data.MedicalCareEntity.Fala = new FalaStatus(FalaStatusType.DISFASIA.ToString());
            } else if (data.Fala == "DISARTRIA") {
                data.MedicalCareEntity.Fala = new FalaStatus(FalaStatusType.DISARTRIA.ToString());
            }

            if(data.NivelDeConsciencia == "CONSCIENTE"){
                data.MedicalCareEntity.NivelDeConsciencia = new NivelDeConscienciaStatus(NivelDeConscienciaStatusType.CONSCIENTE.ToString());
            } else if (data.NivelDeConsciencia == "LETARGICO") {
                data.MedicalCareEntity.NivelDeConsciencia = new NivelDeConscienciaStatus(NivelDeConscienciaStatusType.LETARGICO.ToString());
            } else if (data.NivelDeConsciencia == "INCONSCIENTE") {
                data.MedicalCareEntity.NivelDeConsciencia = new NivelDeConscienciaStatus(NivelDeConscienciaStatusType.INCONSCIENTE.ToString());
            } else if (data.NivelDeConsciencia == "RESPOSTA_AO_ESTIMULO_DOLOROSO") {
                data.MedicalCareEntity.NivelDeConsciencia = new NivelDeConscienciaStatus(NivelDeConscienciaStatusType.RESPOSTA_AO_ESTIMULO_DOLOROSO.ToString());
            } else if (data.NivelDeConsciencia == "RESPOSTA_AO_ESTIMULO_VERBAL") {
                data.MedicalCareEntity.NivelDeConsciencia = new NivelDeConscienciaStatus(NivelDeConscienciaStatusType.RESPOSTA_AO_ESTIMULO_VERBAL.ToString());
            }

            if(data.RespostaMotora == "PLEGIA"){
                data.MedicalCareEntity.RespostaMotora = new RespostaMotoraStatus(RespostaMotoraStatusType.PLEGIA.ToString());
            } else if (data.RespostaMotora == "DEAMBULA_SEM_AUXILIO") {
                data.MedicalCareEntity.RespostaMotora = new RespostaMotoraStatus(RespostaMotoraStatusType.DEAMBULA_SEM_AUXILIO.ToString());
            } else if (data.RespostaMotora == "DEAMBULA_COM_AUXILIO") {
                data.MedicalCareEntity.RespostaMotora = new RespostaMotoraStatus(RespostaMotoraStatusType.DEAMBULA_COM_AUXILIO.ToString());
            } else if (data.RespostaMotora == "CLAUDIACAO") {
                data.MedicalCareEntity.RespostaMotora = new RespostaMotoraStatus(RespostaMotoraStatusType.CLAUDIACAO.ToString());
            }

            return data.MedicalCareEntity;
        }
        
        public static MedicalCareEntity CreateCardio(CreateCardioDTO data)
        {
            if(data.Bulhas == "NORMOFONETICAS"){
                data.MedicalCareEntity.Bulhas = new BulhasStatus(BulhasStatusType.NORMOFONETICAS.ToString());
            } else if (data.Bulhas == "HIPOFONETICAS") {
                data.MedicalCareEntity.Bulhas = new BulhasStatus(BulhasStatusType.HIPOFONETICAS.ToString());
            } else if (data.Bulhas == "HIPERFONETICAS") {
                data.MedicalCareEntity.Bulhas = new BulhasStatus(BulhasStatusType.HIPERFONETICAS.ToString());
            } else if (data.Bulhas == "PRESANCA_DE_SOPRO") {
                data.MedicalCareEntity.Bulhas = new BulhasStatus(BulhasStatusType.PRESANCA_DE_SOPRO.ToString());
            }

            if(data.Ritmo == "SINUSAL"){
                data.MedicalCareEntity.Ritmo = new RitmoStatus(RitmoStatusType.SINUSAL.ToString());
            } else if (data.Ritmo == "TAQUICARDIA") {
                data.MedicalCareEntity.Ritmo = new RitmoStatus(RitmoStatusType.TAQUICARDIA.ToString());
            } else if (data.Ritmo == "BRADICARDIA") {
                data.MedicalCareEntity.Ritmo = new RitmoStatus(RitmoStatusType.BRADICARDIA.ToString());
            }

            if(data.Pulso == "FILIFORME"){
                data.MedicalCareEntity.Pulso = new PulsoStatus(PulsoStatusType.FILIFORME.ToString());
            } else if (data.Pulso == "NORMOESFIGMICO") {
                data.MedicalCareEntity.Pulso = new PulsoStatus(PulsoStatusType.NORMOESFIGMICO.ToString());
            } else if (data.Pulso == "TAQUIEAFIGMICO") {
                data.MedicalCareEntity.Pulso = new PulsoStatus(PulsoStatusType.TAQUIEAFIGMICO.ToString());
            } else if (data.Pulso == "BRADESFIGMICO") {
                data.MedicalCareEntity.Pulso = new PulsoStatus(PulsoStatusType.BRADESFIGMICO.ToString());
            }

            return data.MedicalCareEntity;
        }

    }
}

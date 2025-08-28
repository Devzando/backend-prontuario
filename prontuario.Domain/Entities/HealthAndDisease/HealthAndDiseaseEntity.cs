using prontuario.Domain.Entities.MedicalRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Domain.Entities.HealthAndDisease
{
    public class HealthAndDiseaseEntity
    {
        public long Id { get; private set; }

        // Antecedentes familiares
        public bool FamilyHAS { get; private set; }
        public bool FamilyDM { get; private set; }
        public bool FamilyIAM { get; private set; }
        public bool FamilyAVC { get; private set; }
        public bool FamilyAlzheimer { get; private set; }
        public bool FamilyCA { get; private set; }

        // Antecedentes pessoais
        public bool OwnHAS { get; private set; }
        public bool OwnDM { get; private set; }
        public bool OwnIAM { get; private set; }
        public bool OwnAVC { get; private set; }
        public bool OwnAlzheimer { get; private set; }
        public bool OwnCA { get; private set; }

        public long MedicalRecordId { get; private set; }
        public MedicalRecordEntity MedicalRecord { get; set; } = null!;

        public HealthAndDiseaseEntity() { }

        public HealthAndDiseaseEntity(
            bool familyHAS, bool familyDM, bool familyIAM, bool familyAVC, bool familyAlzheimer, bool familyCA,
            bool ownHAS, bool ownDM, bool ownIAM, bool ownAVC, bool ownAlzheimer, bool ownCA, long medicalRecordId)
        {
            FamilyHAS = familyHAS;
            FamilyDM = familyDM;
            FamilyIAM = familyIAM;
            FamilyAVC = familyAVC;
            FamilyAlzheimer = familyAlzheimer;
            FamilyCA = familyCA;


            OwnHAS = ownHAS;
            OwnDM = ownDM;
            OwnIAM = ownIAM;
            OwnAVC = ownAVC;
            OwnAlzheimer = ownAlzheimer;
            OwnCA = ownCA;

            MedicalRecordId = medicalRecordId;
        }
    }

}

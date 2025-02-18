using prontuario.Domain.Dtos.HealthAndDisease;
using prontuario.Domain.Entities.HealthAndDisease;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prontuario.Application.Factories
{
    public class HealthAndDiseaseFactory
    {
        public static HealthAndDiseaseEntity CreateHealthAndDiseaseEntity(CreateHealthAndDiseaseDTO data)
        {
            return new HealthAndDiseaseBuilder()
                .WithFamilyHAS(data.FamilyHAS)
                .WithFamilyDM(data.FamilyDM)
                .WithFamilyIAM(data.FamilyIAM)
                .WithFamilyAVC(data.FamilyAVC)
                .WithFamilyAlzheimer(data.FamilyAlzheimer)
                .WithFamilyCA(data.FamilyCA)
                .WithOwnHAS(data.OwnHAS)
                .WithOwnDM(data.OwnDM)
                .WithOwnIAM(data.OwnIAM)
                .WithOwnAVC(data.OwnAVC)
                .WithOwnAlzheimer(data.OwnAlzheimer)
                .WithOwnCA(data.OwnCA)
                .WithMedicalRecordId(data.MedicalRecordId)
                .Build();
        }
    }

}

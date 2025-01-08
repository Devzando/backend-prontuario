using prontuario.Domain.Entities.Anamnese;
using prontuario.Domain.Entities.Service;

namespace prontuario.Domain.Entities.MedicalRecord;

public class MedicalRecordEntity
{
    public long? Id { get; private set; }
    public AnamneseEntity Anamnese { get; private set; }
    
    public MedicalRecordEntity() { }

    public MedicalRecordEntity(long? id, AnamneseEntity anamnese)
    {
        this.Id = id;
        this.Anamnese = anamnese;
    }
}
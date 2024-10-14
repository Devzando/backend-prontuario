namespace prontuario.Domain.Entities
{
    public class ServiceEntity
    {
        public long Id { get; private set; }
        public PatientEntity patientEntity { get; private set; } = null!;
        public DateTime DateService { get; private set; }
        public ServiceEntity() { }

        public ServiceEntity(long id, PatientEntity patientEntity, DateTime DateService)
        {
            this.Id = id;
            this.patientEntity = patientEntity;
            this.DateService = DateService;
        }
        public ServiceEntity(PatientEntity patientEntity, DateTime DateService)
        {
            this.patientEntity = patientEntity;
            this.DateService = DateService;
        }
    }
}

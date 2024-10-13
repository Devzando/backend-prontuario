namespace prontuario.Domain.Entities
{
    public class ServiceEntity
    {
        public Guid Id { get; private set; }
        public PatientEntity patientEntity { get; private set; } = null!;
        public DateTime Date { get; private set; }
        public ServiceEntity() { }

        public ServiceEntity(Guid id, PatientEntity patientEntity, DateTime date)
        {
            this.Id = id;
            this.patientEntity = patientEntity;
            this.Date = date;
        }
    }
}

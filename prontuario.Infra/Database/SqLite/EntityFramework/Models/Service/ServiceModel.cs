using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.MedicalRecord;
using prontuario.Infra.Database.SqLite.EntityFramework.Models.Patient;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models.Service
{
    [Table("Services")]
    public class ServiceModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; private set; }

        [Required]
        [MaxLength(15)]
        public string ServiceStatus { get; private set; } = string.Empty;

        [Required]
        public DateTime ServiceDate { get; private set; }

        [Required]
        public long PatientId { get; private set; } 

        [ForeignKey("PatientId")]
        [Column("Patient_Id")]
        public PatientModel PatientModel { get; private set; } = null!;
        public MedicalRecordModel MedicalRecordModel { get; private set; } = null!;
        public ServiceModel() { }
        public ServiceModel(long? id, string serviceStatus, DateTime serviceDate, MedicalRecordModel medicalRecordModel)
        {
            this.Id = id;
            this.ServiceStatus = serviceStatus;
            this.ServiceDate = serviceDate;
            this.MedicalRecordModel = medicalRecordModel;
        }
    }
    
}

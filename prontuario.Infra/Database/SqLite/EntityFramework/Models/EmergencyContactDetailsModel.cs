using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prontuario.Infra.Database.SqLite.EntityFramework.Models
{
    [Table("EmergencyContactDetails")]
    public class EmergencyContactDetailsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; private set; } = string.Empty;
        [Required]
        [MaxLength(15)]
        public string Phone { get; private set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Relationship { get; private set; } = string.Empty;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; private set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; private set; }

        [Required]
        public long PatientId { get; set; }

        [ForeignKey("PatientId")]
        [Column("Patient_Id")]
        public PatientModel PatientModel { get; set; } = null!;

        public EmergencyContactDetailsModel() { }
        public EmergencyContactDetailsModel(
            long id,
            string name,
            string phone,
            string relationship)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
        public EmergencyContactDetailsModel(
            string name,
            string phone,
            string relationship)
        {
            this.Name = name;
            this.Phone = phone;
            this.Relationship = relationship;
        }
    }
}

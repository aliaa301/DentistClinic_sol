using System.ComponentModel.DataAnnotations;

namespace DentistClinic.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "FullName Must be more than 4 character")]
        public string FullName { get; set; } = null!;
        public string? Gender { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.Now;
        public string? Occupation { get; set; }
        public string? Address { get; set; }
        public double CurentBalance { get; set; } = 0;
        public Boolean IsDeleted { get; set; } = false;
        public byte[]? ProfilePicture { get; set; }
        public virtual ICollection<PaymentRecord>? PaymentRecords { get; set; }
        public virtual ICollection<Appointment>? Appointments { get; set; }
        public virtual ICollection<ChiefComplainPatient>? ChiefComplainPatients { get; set; }
        public virtual ICollection<Tplans>? Tplans { get; set; }
        public virtual ICollection<MedicalHistory>? MedicalHistories { get; set; }
        public virtual ICollection<Prescription>? Prescriptions { get; set;}

    }
}

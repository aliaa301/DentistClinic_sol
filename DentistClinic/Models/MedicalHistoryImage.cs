namespace DentistClinic.Models
{
    public class MedicalHistoryImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int MedicalHistoryId { get; set; }
        public virtual MedicalHistory? MedicalHistory { get; set; }

    }
}

namespace DentistClinic.Models
{
    public class XrayPrescriptionImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int XrayPrescriptionId { get; set; }
        public virtual XrayPrescription? XrayPrescription { get; set; }
    }
}

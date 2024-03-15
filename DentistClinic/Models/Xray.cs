namespace DentistClinic.Models
{
    public class Xray
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual ICollection<XrayPrescription>? XrayPrescriptions { get; set; }

    }
}

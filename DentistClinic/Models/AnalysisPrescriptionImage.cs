namespace DentistClinic.Models
{
    public class AnalysisPrescriptionImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int AnalysisPrescriptionId { get; set; }
        public virtual AnalysisPrescription? AnalysisPrescription { get; set; }
    }
}

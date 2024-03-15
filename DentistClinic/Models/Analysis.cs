namespace DentistClinic.Models
{
    public class Analysis
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public virtual ICollection<AnalysisPrescription>? AnalysisPrescriptions { get; set; }
    }
}

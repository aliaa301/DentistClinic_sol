using DentistClinic.CustomeValidation;
using System.ComponentModel.DataAnnotations;

namespace DentistClinic.ViewModels
{
    public class AutomaticAppointmentViewModel
    {
        [CurrentDateCustoumeValidation(ErrorMessage = "Date must be more than today date")]
        [Required(ErrorMessage = "*")]
        public DateOnly Date { get; set; }
        [Range(8,23,ErrorMessage ="Start hour between 8 and 23")]
        [Required(ErrorMessage = "*")]
        public int StartHour {  get; set; }
        [Required(ErrorMessage = "*")]
        [Range(8, 23, ErrorMessage = "End hour between 8 and 23")]
        public int EndHour { get; set; }
        [Required(ErrorMessage = "*")]
        [Range(10, 120, ErrorMessage = "Duration between 10 min and 120 min")]
        public int SessionDurationByMinutes { get; set; }
    }
}

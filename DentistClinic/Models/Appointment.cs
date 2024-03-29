﻿using DentistClinic.CustomeValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DentistClinic.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="*")]
        [CurrentDateCustoumeValidation(ErrorMessage ="date must be more than today date")]
        public DateOnly Date { get; set; }
        [Required(ErrorMessage = "*")]
        public TimeOnly StartTime { get; set; }
        [Required(ErrorMessage = "*")]
        //[Remote("CheckEndMoreThanStart", "Appointments",AdditionalFields = "StartTime")]
        public TimeOnly EndTime { get; set;}
        public int? PatientId { get; set; }
        public virtual Patient? Patient { get; set; }

    }
}

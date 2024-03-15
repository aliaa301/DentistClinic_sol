using DentistClinic.Models;
using DentistClinic.Services;
using DentistClinic.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DentistClinic.Controllers
{
    public class AppointmentsController : Controller
    {   
        IAppointment appointment;
        ApplicationDbContext DB;
        public AppointmentsController(IAppointment _appointment, ApplicationDbContext _DB) 
        {
            appointment = _appointment;
            DB = _DB;
        }
        public IActionResult UpComming()
        {
            var model=appointment.UpComming();
            return View(model);
        }
        
        public IActionResult PreviousAppointments()
        {
            var model = appointment.PreviousAppointments();
            return View(model);
        }

        public IActionResult AddManualy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddManualy(Appointment appoint)
        {
            if (ModelState.IsValid) 
            {
                if (appoint.EndTime > appoint.StartTime) { 
                    appointment.add(appoint);
                    return RedirectToAction("UpComming");
                }
                ModelState.AddModelError("EndTime", "end time must be more than start time");
                return View(appoint);
            }
            return View(appoint);
        }
        //public IActionResult CheckEndMoreThanStart(TimeOnly end,TimeOnly start)
        //{
        //    if (end > start) return Json(true);
        //    return Json("end time must be more than start time");
        //}
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return BadRequest("enter id to delete");
            var deleteApp = appointment.GetById(id);
            if (deleteApp != null)
            {
                appointment.Delete(deleteApp);
                return RedirectToAction("UpComming");
            }
            return NotFound();
        }
        public IActionResult Edit(int id)
        {
            if (id == 0)
                return BadRequest("enter id to edit");
            var model = appointment.GetById(id);
            if (model != null)
                return View(model);
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Appointment app, int id)
        {
            if (ModelState.IsValid)
            {
                if (app.EndTime > app.StartTime)
                {
                    if (app.PatientId != null)
                    {
                        var temp = DB.Patients.FirstOrDefault(patient => patient.Id == app.PatientId);
                        if (temp == null) 
                        {
                            ModelState.AddModelError("PatientId", "This Id Does Not Exist");
                            return View(app);
                        }
                    }
                    appointment.Update(app);
                    return RedirectToAction("UpComming");
                }
                ModelState.AddModelError("EndTime", "end time must be more than start time");
                return View(app);
            }
            return View(app);
        }
        public IActionResult AddAutomaticaly()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAutomaticaly(AutomaticAppointmentViewModel appoint)
        {
            if (ModelState.IsValid)
            {
                if (appoint.EndHour > appoint.StartHour)
                {
                    int counter = (appoint.EndHour - appoint.StartHour)*60 /appoint.SessionDurationByMinutes;
                    if (counter < 1)
                    {
                        ModelState.AddModelError("", "Cannot Create appointments with This Values");
                        return View(appoint);
                    }
                    TimeOnly initTime = new TimeOnly(appoint.StartHour, 0, 0);
                    for (int i = 0;i<counter;i++)
                    {
                        Appointment obj = new Appointment()
                        {
                            Date = appoint.Date,
                            StartTime= initTime,
                            EndTime=initTime.AddMinutes(appoint.SessionDurationByMinutes)
                        };
                        appointment.add(obj);
                        initTime= initTime.AddMinutes(appoint.SessionDurationByMinutes);
                    }
                    return RedirectToAction("UpComming");
                }
                ModelState.AddModelError("EndHour", "End Hour must be more than start hour");
                return View(appoint);
            }
            return View(appoint);
        }

    }
}

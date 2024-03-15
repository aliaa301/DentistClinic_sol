using DentistClinic.Models;

namespace DentistClinic.Services
{
    public class AppointmentRepo:IAppointment
    {
        ApplicationDbContext DB;
        public AppointmentRepo(ApplicationDbContext _db)
        {
            DB= _db;
        }

        public void add(Appointment appointment)
        {
            DB.Appointments.Add(appointment);
            DB.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            DB.Appointments.Remove(appointment);
            DB.SaveChanges();
        }

        public Appointment? GetById(int id)
        {
            return DB.Appointments.FirstOrDefault(app=>app.Id==id);
        }

        public List<Appointment> PreviousAppointments()
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            return DB.Appointments.Where(a => a.Date < today
            || (a.Date == today && a.StartTime < time)).ToList();
        }

        public List<Appointment> UpComming()
        {
            DateOnly today=DateOnly.FromDateTime(DateTime.Today);
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            return DB.Appointments.Where(a=>a.Date > today 
            ||(a.Date == today && a.StartTime > time)).ToList();
        }

        public void Update(Appointment appointment)
        {
            DB.Appointments.Update(appointment);
            DB.SaveChanges();
        }
    }
}

using DentistClinic.Models;

namespace DentistClinic.Services
{
    public interface IAppointment
    {
        List<Appointment> UpComming();
        void add(Appointment appointment);
        List<Appointment> PreviousAppointments();
        void Delete(Appointment appointment);
        Appointment? GetById(int id);
        void Update(Appointment appointment);
    }
}

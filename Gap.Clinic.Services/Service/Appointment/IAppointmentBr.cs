namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IAppointmentBr
    {
        Task Create(Appointment appointment);
        Task Delete(int appointmentId);
        Task Update(Appointment patient);
        Task<Appointment> Get(int appointmentId);
        Task<List<Appointment>> List();
    }
}
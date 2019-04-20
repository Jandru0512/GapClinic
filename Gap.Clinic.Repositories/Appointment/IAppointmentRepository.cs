using System.Collections.Generic;
using System.Threading.Tasks;
using Gap.Clinic.Models;

namespace Gap.Clinic.Repositories
{
    public interface IAppointmentRepository
    {
        Task<Appointment> Create(Appointment appointment);
        Task Delete(int appointmentId);
        Task<Appointment> Get(int appointmentId);
        Task<List<Appointment>> List();
        Task Update(Appointment appointment);
    }
}
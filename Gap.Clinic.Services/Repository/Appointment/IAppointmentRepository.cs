namespace Gap.Clinic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IAppointmentRepository
    {
        Task Delete(int appointmentId);
        Task Update(Appointment appointment);
        Task<Appointment> Get(int appointmentId);
        Task<Appointment> Get(DateTime date);
        Task<Appointment> Create(Appointment appointment);
        Task<List<Appointment>> List();
    }
}
namespace Gap.Clinic.Repositories
{
    using Persistence;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        #region Constructor
        public AppointmentRepository(ClinicContext context) : base(context)
        {

        }
        #endregion

        #region Public Methods
        public async Task<List<Appointment>> List()
        {
            List<Appointment> appointments = await GetAllAsync();
            return appointments.OrderBy(x=>x.Status).ThenByDescending(x=>x.Date).ToList();
        }

        public async Task<Appointment> Get(int appointmentId)
        {
            Appointment appointment = (await FindByAsync(x => x.PatientId == appointmentId)).FirstOrDefault();
            return appointment;
        }

        public async Task Delete(int appointmentId)
        {
            Appointment appointment = (await FindByAsync(x => x.AppointmentId == appointmentId)).FirstOrDefault();
            Delete(appointment);
            await SaveAsync();
        }

        public async Task<Appointment> Create(Appointment appointment)
        {
            appointment = Add(appointment);
            await SaveAsync();
            return appointment;
        }

        public async Task Update(Appointment appointment)
        {
            Appointment entity = (await FindByAsync(x => x.AppointmentId == appointment.AppointmentId)).FirstOrDefault();
            entity.AppointmentTypeId = appointment.AppointmentTypeId;
            entity.PatientId = appointment.PatientId;
            entity.Date = appointment.Date;
            entity.Status = appointment.Status;

            Edit(entity);
            await SaveAsync();
        }
        #endregion
    }
}

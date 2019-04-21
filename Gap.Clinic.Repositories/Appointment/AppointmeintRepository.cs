namespace Gap.Clinic.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Persistence;
    using Services;

    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        #region Constructor
        public AppointmentRepository(ClinicContext context, IInclude include) : base(context)
        {
            _include = include;
        }
        #endregion

        #region Private Attributes
        private readonly IInclude _include;
        #endregion

        #region Public Methods
        public async Task<List<Appointment>> List()
        {
            _include.Add(nameof(Appointment.Patient));
            _include.Add(nameof(Appointment.AppointmentType));
            List<Appointment> appointments = await GetAllAsync(_include.Get());
            return appointments.OrderBy(x=>x.Status).ThenByDescending(x=>x.Date).ToList();
        }

        public async Task<Appointment> Get(int appointmentId)
        {
            Appointment appointment = (await FindByAsync(x => x.AppointmentId == appointmentId)).FirstOrDefault();
            return appointment;
        }

        public async Task<Appointment> Get(DateTime date)
        {
            Appointment appointment = (await FindByAsync(x => x.Date.Date == date.Date)).FirstOrDefault();
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

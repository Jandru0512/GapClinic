﻿namespace Gap.Clinic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Gap.Clinic.Models;

    public class AppointmentBr : IAppointmentBr
    {
        #region Constructor
        public AppointmentBr(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        #endregion

        #region Private Attributes
        private readonly IAppointmentRepository _appointmentRepository;
        #endregion

        #region Public Methods
        public async Task<List<Appointment>> List()
        {
            return await _appointmentRepository.List();
        }

        public async Task<Appointment> Get(int appointmentId)
        {
            return await _appointmentRepository.Get(appointmentId);
        }

        public async Task Delete(int appointmentId)
        {
            Appointment appointment = await _appointmentRepository.Get(appointmentId);
            TimeSpan hours = appointment.Date.Subtract(DateTime.Now);
            //if (<)
            //{

            //}
            //Todo: validación cancelación
            
            //await _appointmentRepository.Delete(appointmentId);
        }

        public async Task Create(Appointment appointment)
        {
            if ((await _appointmentRepository.Get(appointment.Date))!=null)
            {
                throw new Exception("El usuario ya posee una cita para esta fecha");
            }
            appointment.CreationDate = DateTime.Now;
            await _appointmentRepository.Create(appointment);
        }

        public async Task Update(Appointment patient)
        {
            await _appointmentRepository.Update(patient);
        }
        #endregion
    }
}

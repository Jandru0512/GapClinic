namespace Gap.Clinic.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class PatientBr : IPatientBr
    {
        #region Constructor
        public PatientBr(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }
        #endregion

        #region Private Attributes
        private readonly IPatientRepository _patientRepository;
        #endregion

        #region Public Methods
        public async Task<List<Patient>> List()
        {
            return await _patientRepository.List();
        }

        public async Task<Patient> Get(int patientId)
        {
            return await _patientRepository.Get(patientId);
        }

        public async Task Delete(int patientId)
        {
            await _patientRepository.Delete(patientId);
        }

        public async Task Create(Patient patient)
        {
            patient.Date = DateTime.Now;
            await _patientRepository.Create(patient);
        }

        public async Task Update(Patient patient)
        {
            await _patientRepository.Update(patient);
        }
        #endregion
    }
}

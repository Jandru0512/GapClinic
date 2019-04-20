namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IPatientRepository
    {
        Task<List<Patient>> List();
        Task<Patient> Get(int patientId);
        Task<Patient> Create(Patient patient);
        Task Delete(int patientId);
        Task Update(Patient patient);
    }
}
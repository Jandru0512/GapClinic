using System.Collections.Generic;
using System.Threading.Tasks;
using Gap.Clinic.Models;

namespace Gap.Clinic.Services
{
    public interface IPatientBr
    {
        Task<List<Patient>> List();
        Task<Patient> Get(int patientId);
        Task Delete(int patientId);
        Task Create(Patient patient);
        Task Update(Patient patient);
    }
}
namespace Gap.Clinic.Repositories
{
    using Persistence;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Services;
    using System.Linq;

    public class PatientRepository : GenericRepository<Patient>, IPatientRepository
    {
        #region Constructor
        public PatientRepository(ClinicContext context) : base(context)
        {
        }
        #endregion

        #region Public Methods
        public async Task<List<Patient>> List()
        {
            List<Patient> patients = await GetAllAsync();
            return patients.OrderBy(x=>x.LastName).ThenBy(x=>x.Name).ToList();
        }

        public async Task<Patient> Get(int patientId)
        {
            Patient patient = (await FindByAsync(x=>x.PatientId==patientId)).FirstOrDefault();
            return patient;
        }

        public async Task Delete(int patientId)
        {
            Patient patient = (await FindByAsync(x=>x.PatientId==patientId)).FirstOrDefault();
            Delete(patient);
            await SaveAsync();
        }

        public async Task<Patient> Create(Patient patient)
        {
            patient= Add(patient);
            await SaveAsync();
            return patient;
        }

        public async Task Update(Patient patient)
        {
            Patient entity = (await FindByAsync(x => x.PatientId == patient.PatientId)).FirstOrDefault();
            entity.DocumentTypeId = patient.DocumentTypeId;
            entity.Document = patient.Document;
            entity.Name = patient.Name;
            entity.LastName = patient.LastName;
            entity.Email = patient.Email;
            entity.Status = patient.Status;
            entity.BirthDate = patient.BirthDate;

            Edit(entity);
            await SaveAsync();
        }
        #endregion
    }
}

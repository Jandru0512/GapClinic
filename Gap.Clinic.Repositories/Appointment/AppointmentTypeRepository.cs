namespace Gap.Clinic.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Persistence;
    using Services;

    public class AppointmentTypeRepository : GenericRepository<AppointmentType>, IAppointmentTypeRepository
    {
        #region Constructor
        public AppointmentTypeRepository(ClinicContext context): base(context)
        {

        }
        #endregion

        #region Public Methods
        public async Task<List<AppointmentType>> List()
        {
            List<AppointmentType> appointmentTypes = await GetAllAsync();
            return appointmentTypes.OrderBy(x => x.Name).ToList();
        }
        #endregion
    }
}

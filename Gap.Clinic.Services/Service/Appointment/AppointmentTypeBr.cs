namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class AppointmentTypeBr : IAppointmentTypeBr
    {
        #region Constructor
        public AppointmentTypeBr(IAppointmentTypeRepository appointmentType)
        {
            _appointmentType = appointmentType;
        }
        #endregion

        #region Private Attributes
        private readonly IAppointmentTypeRepository _appointmentType;
        #endregion

        #region Public Methods
        public async Task<List<AppointmentType>> List()
        {
            return await _appointmentType.List();
        }
        #endregion

    }
}

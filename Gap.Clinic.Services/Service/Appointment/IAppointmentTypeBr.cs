namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IAppointmentTypeBr
    {
        Task<List<AppointmentType>> List();
    }
}
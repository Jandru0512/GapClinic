namespace Gap.Clinic.Apis.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTypeController : ControllerBase
    {
        #region Constructor
        public AppointmentTypeController(IAppointmentTypeBr appointmentTypeBr)
        {
            _appointmentTypeBr = appointmentTypeBr;
        }
        #endregion

        #region Private Attributes
        private readonly IAppointmentTypeBr _appointmentTypeBr;
        #endregion

        #region Public Methods
        [HttpGet("List")]
        public async Task<List<AppointmentType>> List()
        {
            try
            {
                List<AppointmentType> appointments = await _appointmentTypeBr.List();
                return appointments;
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
                return null;
            }
        }
        #endregion
    }
}

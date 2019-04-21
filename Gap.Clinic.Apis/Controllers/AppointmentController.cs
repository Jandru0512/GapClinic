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
    public class AppointmentController : ControllerBase
    {
        #region Constructor
        public AppointmentController(IAppointmentBr appointmentBr)
        {
            _appointmentBr = appointmentBr;
        }
        #endregion

        #region Private Attributes
        private readonly IAppointmentBr _appointmentBr;
        #endregion

        [HttpGet("List")]
        public async Task<List<Appointment>> List()
        {
            try
            {
                return await _appointmentBr.List();
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
                return null;
            }
        }

        [HttpGet("Get")]
        public async Task<Appointment> Get(int appointmentId)
        {
            try
            {
                return await _appointmentBr.Get(appointmentId);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
                return null;
            }
        }

        [HttpDelete("Delete")]
        public async Task Delete(int appointmentId)
        {
            try
            {
                await _appointmentBr.Delete(appointmentId);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task Create([FromBody] Appointment appointment)
        {
            try
            {
                await _appointmentBr.Create(appointment);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task Update([FromBody] Appointment appointment)
        {
            try
            {
                await _appointmentBr.Update(appointment);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
            }
        }
    }
}

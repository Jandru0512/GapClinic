using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gap.Clinic.Models;
using Gap.Clinic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gap.Clinic.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        #region Constructor
        public PatientController(IPatientBr patientBr)
        {
            _patientBr = patientBr;
        }
        #endregion

        #region Private Attributes
        private readonly IPatientBr _patientBr;
        #endregion

        [HttpGet("List")]
        public async Task<List<Patient>> List()
        {
            try
            {
                return await _patientBr.List();
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
                return null;
            }
        }

        [HttpGet("Get")]
        public async Task<Patient> Get(int patientId)
        {
            try
            {
                return await _patientBr.Get(patientId);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
                return null;
            }
        }

        [HttpDelete("Delete")]
        public async Task Delete(int patientId)
        {
            try
            {
                await _patientBr.Delete(patientId);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
            }
        }

        [HttpPost("Create")]
        public async Task Create([FromBody] Patient patient)
        {
            try
            {
                await _patientBr.Create(patient);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
            }
        }

        [HttpPost("Update")]
        public async Task Update([FromBody] Patient patient)
        {
            try
            {
                await _patientBr.Update(patient);
            }
            catch (Exception ex)
            {
                HttpContext.Response.StatusCode = 500;
                await HttpContext.Response.WriteAsync(ex.Message);
            }
        }
    }
}

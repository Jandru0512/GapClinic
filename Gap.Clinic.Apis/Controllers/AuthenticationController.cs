namespace Gap.Clinic.Apis.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using Services;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        #region Constructor
        public AuthenticationController(IAuthenticationBr authenticationBr)
        {
            _authenticationBr = authenticationBr;
        }
        #endregion

        #region Private Attributes
        private readonly IAuthenticationBr _authenticationBr;
        #endregion

        #region Public Methods
        [HttpPost("Authenticate")]
        public async Task<User> Authenticate([FromBody] Login login)
        {
            try
            {
                User authentication = await _authenticationBr.Authenticate(login);
                return authentication;
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

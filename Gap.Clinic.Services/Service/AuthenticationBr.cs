namespace Gap.Clinic.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Models;

    public class AuthenticationBr : IAuthenticationBr
    {
        #region Constructor
        public AuthenticationBr(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }
        #endregion

        #region Private Attributes
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        #endregion

        #region Public Methods
        public async Task<User> Authenticate(Login login)
        {
            User user = await _userRepository.Find(login);

            if (user == null)
            {
                throw new ArgumentNullException("Credenciales incorrectos");
            }

            Claim[] claims = new[]
            {
                new Claim("UserName", user.UserName),
                new Claim("UserId", user.UserId.ToString())
            };

            user.Token = GenerateToken(claims);
            user.Expiration = DateTime.UtcNow;
            return user;
        }
        #endregion

        #region Private Methods
        private string GenerateToken(Claim[] claimsdata)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            byte[] key = Encoding.ASCII.GetBytes(_configuration["Authentication:SecretKey"]);
            int expiredMinutes = Convert.ToInt32(_configuration["Authentication:ExpirationMinute"]);

            DateTime expiration = DateTime.UtcNow;
            JwtSecurityToken token = new JwtSecurityToken(
                null,
                null,
                claimsdata,
                expiration,
                expiration.AddMinutes(expiredMinutes),
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }
        #endregion
    }
}

namespace Gap.Clinic.Services
{
    using System.Threading.Tasks;
    using Models;

    public interface IAuthenticationBr
    {
        Task<User> Authenticate(Login login);
    }
}
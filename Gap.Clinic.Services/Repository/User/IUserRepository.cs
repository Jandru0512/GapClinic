namespace Gap.Clinic.Services
{
    using System.Threading.Tasks;
    using Models;

    public interface IUserRepository
    {
        Task<User> Find(Login login);
    }
}
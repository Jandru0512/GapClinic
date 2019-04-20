namespace Gap.Clinic.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Persistence;
    using Services;

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        #region Constructor
        public UserRepository(ClinicContext context) : base(context)
        {

        }
        #endregion

        #region Public Methods
        public async Task<User> Find(Login login)
        {
            User user = (await FindByAsync(x => (x.UserName == login.UserName || x.Email == login.UserName) && x.Password == login.Password)).FirstOrDefault();
            return user;
        }
        #endregion
    }
}

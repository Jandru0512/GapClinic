namespace Gap.Clinic.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;
    using Persistence;
    using Services;

    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentTypeRepository
    {
        #region Constructor
        public DocumentTypeRepository(ClinicContext context) : base(context)
        {
        }
        #endregion

        #region Public Methods
        public async Task<List<DocumentType>> List()
        {
            List<DocumentType> patients = await GetAllAsync();
            return patients.OrderBy(x => x.Name).ToList();
        }
        #endregion
    }
}

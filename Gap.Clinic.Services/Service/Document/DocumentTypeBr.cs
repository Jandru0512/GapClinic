namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public class DocumentTypeBr : IDocumentTypeBr
    {
        #region Constructor
        public DocumentTypeBr(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }
        #endregion

        #region Private Attributes
        private readonly IDocumentTypeRepository _documentTypeRepository;
        #endregion

        #region Public Methods
        public async Task<List<DocumentType>> List()
        {
            return await _documentTypeRepository.List();
        }
        #endregion
    }
}

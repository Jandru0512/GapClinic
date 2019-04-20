namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IDocumentTypeRepository
    {
        Task<List<DocumentType>> List();
    }
}
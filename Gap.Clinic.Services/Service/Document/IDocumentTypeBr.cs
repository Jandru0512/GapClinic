namespace Gap.Clinic.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Models;

    public interface IDocumentTypeBr
    {
        Task<List<DocumentType>> List();
    }
}

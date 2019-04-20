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
    public class DocumentTypeController : ControllerBase
    {
        #region Constructor
        public DocumentTypeController(IDocumentTypeBr documentTypeBr)
        {
            _documentTypeBr = documentTypeBr;
        }
        #endregion

        #region Private Attributes
        private readonly IDocumentTypeBr _documentTypeBr;
        #endregion

        #region Public Methods
        [HttpGet("List")]
        public async Task<List<DocumentType>> List()
        {
            try
            {
                return await _documentTypeBr.List();
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

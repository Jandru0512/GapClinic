namespace Gap.Clinic.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }


        public virtual IEnumerable<Patient> Patients { get; set; }
    }
}

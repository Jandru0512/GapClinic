using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gap.Clinic.Models
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int Document { get; set; }
        public int DocumentTypeId { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
        [MaxLength(100), Required]
        public string LastName { get; set; }
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        public bool Status { get; set; }
        [Column(TypeName = "DATETIME2"), Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime BirthDate { get; set; }


        public virtual DocumentType DocumentType { get; set; }
    }
}

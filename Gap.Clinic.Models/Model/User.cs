namespace Gap.Clinic.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        public int UserId { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        public bool Status { get; set; }
        [Column(TypeName = "DATETIME2"), Required]
        public DateTime Date { get; set; }
        [Column(TypeName = "DATETIME2")]
        public DateTime BirthDate { get; set; }
        [NotMapped]
        public string Token { get; set; }
        [NotMapped]
        public DateTime Expiration { get; set; }
    }
}

namespace Gap.Clinic.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AppointmentType
    {
        public int AppointmentTypeId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

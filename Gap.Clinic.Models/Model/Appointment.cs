namespace Gap.Clinic.Models
{
    using System;

    public class Appointment
    {
        public int AppointmentId { get; set; }
        public int AppointmentTypeId { get; set; }
        public int PatientId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual AppointmentType AppointmentType { get; set; }
    }
}

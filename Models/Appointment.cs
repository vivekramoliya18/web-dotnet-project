using System.ComponentModel.DataAnnotations;

namespace MediCareWeb.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    [Display(Name = "Patient name")]
    public string PatientName { get; set; } = string.Empty;
    [Required, StringLength(100)]
    [Display(Name = "Doctor name")]
    public string DoctorName { get; set; } = string.Empty;
    [Required, DataType(DataType.Date)]
    public DateTime AppointmentDate { get; set; } = DateTime.Today;
    [Required]
    public string AppointmentTime { get; set; } = "09:00";
    [StringLength(500)]
    public string? Reason { get; set; }
    public string Status { get; set; } = "Scheduled";
    [StringLength(1000)]
    public string? Diagnosis { get; set; }
    [StringLength(2000)]
    [Display(Name = "Visit notes")]
    public string? VisitNotes { get; set; }
    public DateTime? CompletedAt { get; set; }
}

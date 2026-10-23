using System.ComponentModel.DataAnnotations;

namespace MediCareWeb.Models;

public class Doctor
{
    public int Id { get; set; }
    [Required, StringLength(100)]
    public string FullName { get; set; } = string.Empty;
    [Required, StringLength(80)]
    public string Specialty { get; set; } = string.Empty;
    [Phone]
    public string? Phone { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
}

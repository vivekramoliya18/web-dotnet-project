using System.ComponentModel.DataAnnotations;

namespace MediCareWeb.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Patient name is required")]
[StringLength(100)]
[Display(Name = "Full Name")]
public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Enter a valid phone number")]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; } = string.Empty;

[Required(ErrorMessage = "Date of birth is required")]
[DataType(DataType.Date)]
[Display(Name = "Date of Birth")]
public DateTime DateOfBirth { get; set; }
    }
}
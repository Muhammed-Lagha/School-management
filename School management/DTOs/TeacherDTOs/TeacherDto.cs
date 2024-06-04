using System.ComponentModel.DataAnnotations;

namespace School_management.DTOs
{
    public class TeacherDto
    {
        public int Id { get; set; }

        [Required] public required string FirstName { get; set; } = string.Empty;

        [Required] public string LastName { get; internal set; } = string.Empty;

        [Required] public string NiNo {  get; set; } = string.Empty;

        [Required] public required string Password { get; set; } = string.Empty;

        [Required] public required string BirthDate { get; set; } = string.Empty;
    }
}

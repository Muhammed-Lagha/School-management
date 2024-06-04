namespace School_management.DTOs.RequestDTOs
{
    public class StudentsRequests
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Passwrod { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
    }

    public class StudentLoginRequest
    {
        public string FirstName{ get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

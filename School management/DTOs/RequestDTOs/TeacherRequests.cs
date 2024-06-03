namespace School_management.DTOs.RequestDTOs
{
    public class LoginTeacherRequests
    {
        public string NiNo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
    public class CreateTeacher
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty ;
        public string NeNo { get; set; }  = string.Empty;
        public string Passwrod { get; set; } = string.Empty;
    }
}

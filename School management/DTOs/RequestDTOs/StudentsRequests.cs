﻿namespace School_management.DTOs.RequestDTOs
{
    public class StudentsRequests
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName {  get; set; } = string.Empty;
        public string Passwrod { get; set; } = string.Empty;
        public string DateOfBirth { get; set; } = string.Empty;
        public int GradeId { get; set; }
    }

    public class StudentLoginRequest
    {
        public string UserName{ get; set;} = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}

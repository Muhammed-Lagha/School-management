﻿using DeviseHR_Server.Common;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Methods;
using School_management.Models;
using School_management.Repositories.Student_Repository;

namespace School_management.Services.Student_Service
{

    public class RegistrationStudentServices
    {
        public static async Task<ServiceResponse<Student>> LoginStudentService(string UserName, string Password)
        {
            Student stu = await StudentRepository.GetStudentByUserName(UserName);
            AccessMethods.VerifyStudentPass(stu, Password);
            string token = await Tokens.GenerateStudentAuthJWT(stu);
            stu.Password = string.Empty;
            var serviceResponse = new ServiceResponse<Student>(stu, true, "", token);

            return serviceResponse;
        }

        public static async Task<ServiceResponse<Student>> RegisterStudentServices(StudentsRequests studentsRequests)
        {
            var db = new SchoolManagementContext();

            string hashedPassword = AccessMethods.GenerateHash(studentsRequests.Passwrod);
            DateOnly birthDate = ParseDate.ParseDateOnly(studentsRequests.DateOfBirth);

            Student student = new Student
            {
                FirstName = studentsRequests.FirstName,
                LastName = studentsRequests.LastName,
                Username = studentsRequests.UserName,
                Password = hashedPassword,
                DateOfBirth = birthDate,
                GradeId = studentsRequests.GradeId,
            };

            db.Add(student);
            await db.SaveChangesAsync();

            var serviceResponse = new ServiceResponse<Student>(student, true, "");

            return serviceResponse;
        }
        
    }
}

namespace School_management.DTOs.RequestDTOs
{
    public class CreateSubjectRequests
    {
        public string Name { get; set; } = string.Empty;

        public int GradeNumber { get; set; }

        public int GradeId { get; set; }
    }
    public class UpdateSubjectRequest
    {
        public string Name { get; set; } = string.Empty ;
        public int GradeNumber { get; set;}
        public int GradeId { get; set;}
    }
}

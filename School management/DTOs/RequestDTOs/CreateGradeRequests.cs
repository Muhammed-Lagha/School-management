namespace School_management.DTOs.RequestDTOs
{
    public class CreateGradeRequests
    {
        public string GradeName { get; set; } = string.Empty;

        public int GradeNumber { get; set; }
    }
    public class UpdateGradeRequest
    {
        public string GradeName { get; set; } = string.Empty;
        public int GradeNumber { get; set; }
    }
}

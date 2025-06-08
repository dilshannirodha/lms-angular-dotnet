namespace backend.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public string AssignmentText { get; set;}
        public DateTime? DueDate { get; set; }
    }

}

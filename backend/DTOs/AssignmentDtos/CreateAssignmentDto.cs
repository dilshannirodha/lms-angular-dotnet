namespace backend.DTOs.AssignmentDtos
{

        public class CreateAssignmentDto
        {
            public string CourseId { get; set; }
            public string AssignmentText { get; set; }
        public DateTime? DueDate { get; set; }
    }
    
}

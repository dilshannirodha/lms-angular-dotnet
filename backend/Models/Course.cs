using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Course
    {
        [Key]
        [StringLength(100)]
        public string CourseId { get; set; } = string.Empty;
        public string CourseName { get; set; } = string.Empty;
        public string Assignment { get; set; } = string.Empty;
    }
}

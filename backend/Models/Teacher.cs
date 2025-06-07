using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Teacher
    {
        [Key]
        [StringLength(100)]
        public string TeacherId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

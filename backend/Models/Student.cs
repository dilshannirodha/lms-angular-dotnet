using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Student
    {
        [Key]
        [StringLength(100)]
        public string StudentId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

﻿namespace backend.DTOs.StudentDtos
{
    public class StudentResponseDto
    {
        public string StudentId { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}

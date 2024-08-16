﻿namespace StudentManagement.Models
{
    public class CourseStudent
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
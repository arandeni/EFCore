namespace StudentManagement.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; } = null!;
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public List<CourseStudent> Courses { get; } = [];
        
    }
}

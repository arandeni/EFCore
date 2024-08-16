namespace StudentManagement.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; } = null!;
        public List<CourseStudent> Students { get; } = [];
    }
}

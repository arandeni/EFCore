namespace StudentManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; } = [];
        public List<Student> Students { get; } = [];
    }
}

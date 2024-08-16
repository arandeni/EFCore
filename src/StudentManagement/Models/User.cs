﻿namespace StudentManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserEmail { get; set; } 
        public string Password { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}

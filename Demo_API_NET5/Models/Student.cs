using System;

namespace Demo_API_NET5.Models
{
    public class Student
    {
        public Guid studentId { get; set; }
        public string studentName { get; set; }

        public Student(string name)
        {
            studentName = name;
        }

        public Student()
        {
        }
    }
}

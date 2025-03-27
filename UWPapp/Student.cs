using System;

namespace UWPapp
{
    public class Student
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string CourseGrade { get; set; }

        public Student(string id, string firstName, string lastName, string className, string courseGrade)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Class = className;
            CourseGrade = courseGrade;
        }

        public override string ToString()
        {
            return $"{ID} - {LastName}, {FirstName} - {Class} {CourseGrade}";
        }
    }
}

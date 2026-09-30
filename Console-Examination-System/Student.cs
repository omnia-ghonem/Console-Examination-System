using System;
using System.Collections.Generic;

namespace C45_G83_EXAM02
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public List<ExamResult> Results { get; }

        public Student(int studentId, string name)
        {
            if (studentId <= 0)
                throw new ArgumentOutOfRangeException(nameof(studentId), "Student ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            StudentId = studentId;
            Name = name;
            Results = new List<ExamResult>();
        }

        public void AddResult(ExamResult result)
        {
            Results.Add(result);
        }

        public void DisplayResults()
        {
            Console.WriteLine($"===== Results for {Name} =====");

            if (Results.Count == 0)
            {
                Console.WriteLine("You have not taken any exams yet.");
                return;
            }

            foreach (ExamResult result in Results)
            {
                Console.WriteLine($"{result.ExamTitle} | {result.Grade}/{result.TotalGrade} | {result.Percentage:F1}% | {(result.Passed ? "PASS" : "FAIL")}");
            }
        }
    }
}

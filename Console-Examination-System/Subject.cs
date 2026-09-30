using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Examination_System
{
    public class Subject
    {
        private int SubjectId;
        private string SubjectName;
        private List<Exam> Exams;

        public int subjectId
        {
            get => SubjectId;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(SubjectId), "Subject ID must be greater than zero.");
                SubjectId = value;
            }
        }

        public string subjectName
        {
            get => SubjectName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Subject name cannot be empty.");
                SubjectName = value;
            }
        }

        public List<Exam> exams => Exams;

        public Subject(int subjectId, string subjectName)
        {
            this.subjectId = subjectId;
            this.subjectName = subjectName;
            Exams = new List<Exam>();
        }

        public Exam CreateExam(int examId, string title, int examType, int examTime, int numberOfQuestions)
        {
            Exam exam;

            if (examType == 1)
                exam = new PracticalExam(examId, title, examTime, numberOfQuestions);
            else if (examType == 2)
                exam = new FinalExam(examId, title, examTime, numberOfQuestions);
            else
                throw new ArgumentOutOfRangeException(nameof(examType), "Exam type must be 1 or 2.");

            exam.CreateExam();
            Exams.Add(exam);
            return exam;
        }

        public Exam? FindExam(int examId)
        {
            return Exams.FirstOrDefault(e => e.ExamId == examId);
        }

        public List<Exam> GetActiveExams()
        {
            return Exams.Where(e => e.Status == ExamStatus.Active).ToList();
        }

        public void DisplayAllExams()
        {
            Console.WriteLine($"===== {subjectName} Exams =====");

            if (Exams.Count == 0)
            {
                Console.WriteLine("No exams created yet.");
                return;
            }

            foreach (Exam exam in Exams)
                Console.WriteLine(exam);
        }
    }
}

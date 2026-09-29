using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Examination_System
{
    internal class Program
    {
        private static Subject Mathematics = new Subject(1, "Mathematics");
        private static List<Student> Students = new List<Student>();
        private static int NextExamId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("         EXAM SYSTEM");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Teacher");
                Console.WriteLine("2. Student");
                Console.WriteLine("3. Exit");

                int role = HandleExceptions.HandleNumberExceptions(
                    Check.ReadNumberBetween,
                    1,
                    3,
                    "Choose user type: ");

                if (role == 1)
                    TeacherMenu();
                else if (role == 2)
                    StudentMenu();
                else
                    break;
            }
        }

        private static void TeacherMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==============================");
                Console.WriteLine("        TEACHER MENU");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Create Exam");
                Console.WriteLine("2. View Exams");
                Console.WriteLine("3. Change Exam Status");
                Console.WriteLine("4. Back");

                int choice = HandleExceptions.HandleNumberExceptions(
                    Check.ReadNumberBetween,
                    1,
                    4,
                    "Choose an option: ");

                if (choice == 1)
                    CreateExam();
                else if (choice == 2)
                {
                    Console.Clear();
                    Mathematics.DisplayAllExams();
                    Pause();
                }
                else if (choice == 3)
                    ChangeExamStatus();
                else
                    return;
            }
        }

        private static void CreateExam()
        {
            Console.Clear();
            Console.WriteLine("===== Create Exam =====");

            string title = HandleExceptions.HandleStringExceptions(
                Check.ReadString,
                "Enter exam title: ");

            int examType = HandleExceptions.HandleNumberExceptions(
                Check.ReadNumberBetween,
                1,
                2,
                "Enter exam type (1 Practical, 2 Final): ");

            int minutes = HandleExceptions.HandleNumberExceptions(
                Check.ReadNumberBetween,
                30,
                180,
                "Enter exam time (30-180 minutes): ");

            int numberOfQuestions = HandleExceptions.HandleNumberExceptions(
                Check.ReadPositiveNumber<int>,
                "Enter number of questions: ");

            Console.Clear();

            Exam exam = Mathematics.CreateExam(
                NextExamId,
                title,
                examType,
                minutes,
                numberOfQuestions);

            NextExamId++;

            Console.WriteLine($"Exam '{exam.Title}' was created successfully.");
            Console.WriteLine("Its status is Draft. Activate it before students can take it.");
            Pause();
        }

        private static void ChangeExamStatus()
        {
            Console.Clear();
            Mathematics.DisplayAllExams();

            if (Mathematics.exams.Count == 0)
            {
                Pause();
                return;
            }

            int examId = HandleExceptions.HandleNumberExceptions(
                Check.ReadPositiveNumber<int>,
                "Enter exam ID: ");

            Exam? exam = Mathematics.FindExam(examId);

            if (exam == null)
            {
                Console.WriteLine("Exam not found.");
                Pause();
                return;
            }

            int status = HandleExceptions.HandleNumberExceptions(
                Check.ReadNumberBetween,
                1,
                3,
                "Choose status: 1 Draft, 2 Active, 3 Closed: ");

            exam.Status = (ExamStatus)status;
            Console.WriteLine($"'{exam.Title}' status changed to {exam.Status}.");
            Pause();
        }

        private static void StudentMenu()
        {
            Console.Clear();

            int studentId = HandleExceptions.HandleNumberExceptions(
                Check.ReadPositiveNumber<int>,
                "Enter student ID: ");

            Student? student = Students.FirstOrDefault(s => s.StudentId == studentId);

            if (student == null)
            {
                string studentName = HandleExceptions.HandleStringExceptions(
                    Check.ReadString,
                    "Enter student name: ");

                student = new Student(studentId, studentName);
                Students.Add(student);
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {student.Name}");
                Console.WriteLine();
                Console.WriteLine("1. View Active Exams");
                Console.WriteLine("2. Start Exam");
                Console.WriteLine("3. View My Results");
                Console.WriteLine("4. Back");

                int choice = HandleExceptions.HandleNumberExceptions(
                    Check.ReadNumberBetween,
                    1,
                    4,
                    "Choose an option: ");

                if (choice == 1)
                    DisplayActiveExams();
                else if (choice == 2)
                    StartStudentExam(student);
                else if (choice == 3)
                {
                    Console.Clear();
                    student.DisplayResults();
                    Pause();
                }
                else
                    return;
            }
        }

        private static void DisplayActiveExams()
        {
            Console.Clear();
            List<Exam> activeExams = Mathematics.GetActiveExams();

            Console.WriteLine("===== Active Exams =====");

            if (activeExams.Count == 0)
                Console.WriteLine("There are no active exams.");
            else
            {
                foreach (Exam exam in activeExams)
                    Console.WriteLine(exam);
            }

            Pause();
        }

        private static void StartStudentExam(Student student)
        {
            Console.Clear();
            List<Exam> activeExams = Mathematics.GetActiveExams();

            if (activeExams.Count == 0)
            {
                Console.WriteLine("There are no active exams.");
                Pause();
                return;
            }

            Console.WriteLine("===== Active Exams =====");
            foreach (Exam exam in activeExams)
                Console.WriteLine(exam);

            int examId = HandleExceptions.HandleNumberExceptions(
                Check.ReadPositiveNumber<int>,
                "Enter exam ID to start: ");

            Exam? selectedExam = activeExams.FirstOrDefault(e => e.ExamId == examId);

            if (selectedExam == null)
            {
                Console.WriteLine("Invalid exam ID.");
                Pause();
                return;
            }

            string confirm = HandleExceptions.HandleStringExceptions(
                Check.ReadString,
                $"Start '{selectedExam.Title}'? (Y/N): ");

            if (!confirm.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exam cancelled.");
                Pause();
                return;
            }

            Console.Clear();
            ExamResult result = selectedExam.StartExam();
            student.AddResult(result);
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}

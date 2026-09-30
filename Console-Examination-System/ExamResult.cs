using System;

namespace Console_Examination_System
{
    public class ExamResult
    {
        public int ExamId { get; set; }
        public string ExamTitle { get; set; } = string.Empty;
        public double Grade { get; set; }
        public double TotalGrade { get; set; }
        public double Percentage { get; set; }
        public bool Passed { get; set; }
        public int CorrectAnswers { get; set; }
        public int WrongAnswers { get; set; }
        public double TimeTakenSeconds { get; set; }
        public DateTime DateTaken { get; set; }

        public void Display()
        {
            Console.WriteLine("================================");
            Console.WriteLine("          EXAM RESULT");
            Console.WriteLine("================================");
            Console.WriteLine($"Exam: {ExamTitle}");
            Console.WriteLine($"Grade: {Grade} / {TotalGrade}");
            Console.WriteLine($"Percentage: {Percentage:F1}%");
            Console.WriteLine($"Correct answers: {CorrectAnswers}");
            Console.WriteLine($"Wrong answers: {WrongAnswers}");
            Console.WriteLine($"Result: {(Passed ? "PASS" : "FAIL")}");
            Console.WriteLine($"Time: {TimeTakenSeconds:F1} seconds");
            Console.WriteLine($"Date: {DateTaken:dd/MM/yyyy HH:mm}");
            Console.WriteLine("================================");
        }
    }
}

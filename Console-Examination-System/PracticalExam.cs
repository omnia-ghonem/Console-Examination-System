using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Console_Examination_System
{
    public class PracticalExam : Exam
    {
        public PracticalExam(int examId, string title, int time, int numberOfQuestions)
            : base(examId, title, time, numberOfQuestions)
        {
        }

        public override void CreateExam()
        {
            for (int i = 0; i < numberOfQuestions; i++)
            {
                questionList.Add(Creation.CreateMCQ($"Question {i + 1}"));
                Console.Clear();
            }
        }

        public override ExamResult StartExam()
        {
            if (Status != ExamStatus.Active)
                throw new InvalidOperationException("This exam is not active.");

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<int> selectedAnswers = new List<int>();
            double grade = 0;
            int correctCount = 0;
            int wrongCount = 0;

            for (int i = 0; i < questionList.Count; i++)
            {
                Console.WriteLine($"Exam: {Title}");
                Console.WriteLine($"Question {i + 1} of {questionList.Count}");
                Console.WriteLine();

                questionList[i].DisplayQuestion();
                questionList[i].DisplayChoices();

                int answer = HandleExceptions.HandleNumberExceptions(
                    Check.ReadNumberBetween,
                    1,
                    4,
                    "Please enter a valid answer (1-4): ");

                selectedAnswers.Add(answer);

                if (questionList[i].IsAnswerCorrect(answer))
                {
                    grade += questionList[i].mark;
                    correctCount++;
                }
                else
                {
                    wrongCount++;
                }

                Console.Clear();
            }

            stopwatch.Stop();

            Console.WriteLine($"===== Review: {Title} =====");

            for (int i = 0; i < questionList.Count; i++)
            {
                Question question = questionList[i];
                question.DisplayQuestion();
                Console.WriteLine($"Your answer => {question.answerlist[selectedAnswers[i] - 1].answerText}");
                Console.WriteLine($"Correct answer => {question.answerlist[question.rightAnswer - 1].answerText}");
                Console.WriteLine();
            }

            double totalGrade = GetTotalMark();
            double percentage = totalGrade == 0 ? 0 : grade / totalGrade * 100;

            ExamResult result = new ExamResult
            {
                ExamId = ExamId,
                ExamTitle = Title,
                Grade = grade,
                TotalGrade = totalGrade,
                Percentage = percentage,
                Passed = percentage >= 50,
                CorrectAnswers = correctCount,
                WrongAnswers = wrongCount,
                TimeTakenSeconds = stopwatch.Elapsed.TotalSeconds,
                DateTaken = DateTime.Now
            };

            result.Display();
            return result;
        }
    }
}

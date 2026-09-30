using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Examination_System
{
    public enum ExamStatus
    {
        Draft = 1,
        Active = 2,
        Closed = 3
    }

    public abstract class Exam
    {
        private int Time;
        private int NumberOfQuestions;
        private List<Question> QuestionList;

        public int ExamId { get; set; }
        public string Title { get; set; }
        public ExamStatus Status { get; set; }

        public int time
        {
            get => Time;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Time), "Exam time must be greater than zero.");
                Time = value;
            }
        }

        public int numberOfQuestions
        {
            get => NumberOfQuestions;
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(NumberOfQuestions), "Number of questions must be greater than zero.");
                NumberOfQuestions = value;
            }
        }

        public List<Question> questionList
        {
            get => QuestionList;
            private set
            {
                if (value == null)
                    throw new ArgumentException("Question list cannot be null.");
                QuestionList = value;
            }
        }

        protected Exam(int examId, string title, int time, int numberOfQuestions)
        {
            if (examId <= 0)
                throw new ArgumentOutOfRangeException(nameof(examId), "Exam ID must be greater than zero.");
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Exam title cannot be empty.");

            ExamId = examId;
            Title = title;
            this.time = time;
            this.numberOfQuestions = numberOfQuestions;
            questionList = new List<Question>();
            Status = ExamStatus.Draft;
        }

        public abstract void CreateExam();
        public abstract ExamResult StartExam();

        public double GetTotalMark()
        {
            return questionList.Sum(q => q.mark);
        }

        public override string ToString()
        {
            return $"ID: {ExamId} | {Title} | {GetType().Name.Replace("Exam", "")} | {time} min | {numberOfQuestions} questions | {Status}";
        }
    }
}

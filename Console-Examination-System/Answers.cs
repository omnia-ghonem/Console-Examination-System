using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Examination_System
{
    public class Answers
    {
        private int AnswerId;
        private string AnswerText;

        public int answerId
        {
            get => AnswerId; 
            set 
            { 
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(AnswerId), "Answer ID must be greater than zero.");
                }
                AnswerId = value;
            }
        }

        public string answerText
        {
            get => AnswerText;  
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Answer text cannot be null or whitespace.");
                }
                AnswerText = value;
            }
        }

        public Answers(int answerId, string answerText)
        {
            this.answerId = answerId;
            this.answerText = answerText;
        }
    }
}

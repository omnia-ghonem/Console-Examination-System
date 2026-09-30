using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G83_EXAM02
{
    public abstract class Question: ICloneable, IComparable
    {
        private string Header;
        private string Body;
        private double Mark;

        private Answers[] AnswerList;   // list of the mcq answers or true , false answers

        private int RightAnswer;
        public string header
        {
            get => Header; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Question header cannot be null or whitespace.");
                Header = value;
                
                 
            
            }
        }
        public string body
        {
            get => Body; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Question body cannot be null or whitespace.");
                Body = value;
                
                 
            }
        }
        public double mark
        {
            get => Mark; 
            set 
            { 
                if (value <= 0)
                    throw new ArgumentOutOfRangeException(nameof(Mark),"Question mark must be greater than zero.");
                    
   
                Mark = value;
            }
        }


        public Answers[] answerlist
        {
            get => AnswerList;

            set
            {
                if (value == null || value.Length <= 0)
                    throw new ArgumentException("Question must contain answers.");
                AnswerList = value;
            }
            
        }

        public int rightAnswer
        {
            get => RightAnswer;
            set {

                if (value < 1 || value > answerlist.Length)
                    throw new ArgumentOutOfRangeException(nameof(RightAnswer), "Right answer is out of bounds.");
                RightAnswer = value;
            }
        }



        public Question(string header, string body, double mark, int rightAnswer)
        {
            this.header = header;
            this.body = body;
            this.mark = mark;
            // AnswerList  must be initialized before setting rightAnswer to avoid exception in the rightAnswer setter "value > answerlist.Length"
            this.answerlist = new Answers[2];
            this.rightAnswer = rightAnswer;

        }
        public Question(string header, string body, double mark, Answers[] answerlist, int rightAnswer)
        {
            this.header = header;
            this.body = body;
            this.mark = mark;
            this.answerlist = answerlist;
            this.rightAnswer = rightAnswer;
        }

        public abstract void DisplayQuestion();
        public abstract void DisplayChoices();
        public bool IsAnswerCorrect(int answer)
        {
            return answer == this.rightAnswer;
        }

        public virtual object Clone()
        {             
            // Create a new instance of the Question class with the same values
             Question copiedQuestion = (Question)this.MemberwiseClone();
             copiedQuestion.header = new string(this.header);
             copiedQuestion.body = new string(this.body);
             copiedQuestion.answerlist = new Answers[this.answerlist.Length];
             for (int i = 0; i < this.answerlist.Length; i++)
             {
                 copiedQuestion.answerlist[i] = new Answers(this.answerlist[i].answerId, this.answerlist[i].answerText);
             }
             return copiedQuestion;
        }

        public int CompareTo(object? obj)
        {
            // IF obj IS a Question -> cast it to Question then store that Question reference in otherQuestion
            if (obj is not Question otherQuestion)
            {
                throw new ArgumentException("Object must be a Question.");
            }

            return Mark.CompareTo(otherQuestion.Mark);
        }

        public override string ToString()
        {
              return $"{header}: {body}";
        }
        // \nAnswers: {string.Join(", ", answerlist)}\nRight Answer: {rightAnswer}
    }
}

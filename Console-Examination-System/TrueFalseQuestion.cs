using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Examination_System
{
    public class TrueFalseQuestion: Question
    {
        public TrueFalseQuestion(string header, string body, double mark, int rightAnswer) : base(header, body, mark, rightAnswer)
        {

        }
        public override void DisplayQuestion()
        {
            Console.WriteLine(ToString());
            Console.WriteLine($"True/False Question: Mark {mark}");
  
        }

        public override void DisplayChoices() {

            Answers[] TFanswers = new Answers[]
            { new Answers(1, "True"),
              new Answers(2, "False") };
            foreach (Answers answer in TFanswers)
            {
                Console.WriteLine($"{answer.answerId}- {answer.answerText}");
            }


        }


    }
}       

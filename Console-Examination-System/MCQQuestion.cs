using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Console_Examination_System
{
    public class MCQQuestion: Question
    {
        
        public MCQQuestion(string header, string body, double mark, Answers[] answerlist, int rightAnswer) : base(header, body, mark, answerlist, rightAnswer)
        {

        }
        public override void DisplayQuestion()
        {
            Console.WriteLine(ToString());
            Console.WriteLine($"MCQ Question: Mark {mark}");

        }
        public override void DisplayChoices()
        {
            Console.WriteLine("Answer List:");
            foreach (Answers answer in answerlist)
            {
                Console.WriteLine($"{answer.answerId}- {answer.answerText}");
            }

        }

    }
}

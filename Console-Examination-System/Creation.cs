using System;
using System.Collections.Generic;
using System.Text;

namespace C45_G83_EXAM02
{
    public static class Creation
    {  
        public static MCQQuestion CreateMCQ(string header ) { 
             
            string body = HandleExceptions.HandleStringExceptions(Check.ReadString, "Please enter the question body:");

            double mark = HandleExceptions.HandleNumberExceptions(Check.ReadPositiveNumber<double>, "Please enter the question mark: ");

            string[] choices = new string[4];
            for(int i = 0; i < 4; i++)
            {
                choices[i] = HandleExceptions.HandleStringExceptions(Check.ReadString, $"Please enter Choice number {i + 1}: ");
            }

            int CorrectAnswer = HandleExceptions.HandleNumberExceptions(Check.ReadNumberBetween, 1, 4, "Please enter the ID of the correct answer: ");

            Answers[] answers = new Answers[4];
            for (int i = 0; i < 4; i++)
            {
                answers[i] = new Answers(i + 1, choices[i]);
            }

            return new MCQQuestion(header, body, mark, answers, CorrectAnswer);


        }


        public static TrueFalseQuestion CreateTrueFalse(string header)
        {

            string body = HandleExceptions.HandleStringExceptions(Check.ReadString, "Please enter the question body:");

            double mark = HandleExceptions.HandleNumberExceptions(Check.ReadPositiveNumber<double>, "Please enter the question mark: ");

            int CorrectAnswer = HandleExceptions.HandleNumberExceptions(Check.ReadNumberBetween, 1, 2, "Please enter the ID of the correct answer 1 is true and 2 for false : ");

            return new TrueFalseQuestion(header, body, mark, CorrectAnswer);

             
        }
    }
}

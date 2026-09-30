using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Console_Examination_System
{
    public static class Check
    {

        public static int ReadNumberBetween(int start,int end, string? message = null)
        {
            if (message != null)  
            {
                Console.WriteLine(message.TrimStart());
            }
            int number = 0;
            bool isValid = int.TryParse(Console.ReadLine(), out number);
            if (!isValid)
            {
                throw new ArgumentException("Invalid input. Please enter a valid integer.");
            }
            if (number < start || number > end) // delegate the range check to a separate method
            {
                throw new ArgumentOutOfRangeException($"Number must be between {start} and {end}.");
            }
            return number;
        }

        public static T ReadPositiveNumber<T>(string? message = null) where T : INumber<T> 
        {
            if (message != null)
            {
                Console.WriteLine(message.TrimStart());
            }
            T number = T.Zero;
            bool isValid = T.TryParse(Console.ReadLine(),null, out number);
            if (!isValid)
            {
                throw new ArgumentException("Invalid input. Please enter a valid integer.");
            }  
            if (number <= T.Zero) // delegate the range check to a separate method
            {
                throw new ArgumentOutOfRangeException($"Number must be a positive integer.");
            }
            return number;
        }



        public static string ReadString(string? message = null)
        {
            if (message != null)
            {
                Console.WriteLine(message.TrimStart());
            }
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Invalid input. Please enter a valid string.");
            }
            return input;
        }



    }
}

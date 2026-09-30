using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Console_Examination_System
{
    public static class HandleExceptions
    {


        public static int HandleNumberExceptions(
        Func<int, int,string, int> readNumber,
        int min,
        int max, string? message = null)
        {
            // catch is performed in order so catch "ArgumentOutOfRangeException" before "ArgumentException"
            // as ArgumentOutOfRangeException is a more specific type of ArgumentException
            // if we catch ArgumentException first, it will catch all ArgumentOutOfRangeException as well, and we won't be able to handle them separately.
            while (true)
            {
                try
                {
                    return readNumber(min, max, message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
   
            }
        }


        public static T HandleNumberExceptions<T>(
        Func<string,T> readNumber , string? message = null) where T : INumber<T>
        {
            while (true)
            {
                try
                {
                    return readNumber(message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
  
            }
        }




        /*
         = null
        allows YOU to omit the argument when CALLING the method.

        It does NOT change the method's delegate signature.

         
         */
        public static string HandleStringExceptions(
            Func<string,string> sentence , string? message = null)
        {

            while (true)
            {
                try
                {
                    return sentence(message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}

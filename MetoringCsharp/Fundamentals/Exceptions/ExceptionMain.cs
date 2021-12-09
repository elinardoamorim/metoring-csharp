using MetoringCsharp.Fundamentals.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Fundamentals.Exceptions
{
    public class ExceptionMain
    {
        public static void Execute()
        {

            try
            {
                InvalidNumber();
            } 
            catch (ValueNumberInvalidException ex)
            {
                Console.WriteLine(ex.GetType());
                Console.WriteLine(ex.Message);
            }
            //StandardException();
            //Console.WriteLine();
            //CustomException();
            Console.ReadKey();

        }

        public static void InvalidNumber()
        {
            try
            {
                var text = "teste";
                int number = Convert.ToInt32(text);
                Console.WriteLine(number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType());

                throw new ValueNumberInvalidException();

            }
        }

        public static void StandardException()
        {
            try
            {
                var account = new Account(1000);
                //account.Withdraw(100);
                //OR
                account.Withdraw(1100); //Trigger the exception
                Console.WriteLine("Successful withdrawal!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Thanks!");
            }
        }

        public static void CustomException()
        {
            try
            {
                var value = PositiveAndPar();
                Console.WriteLine(value);
            }
            catch (NegativeException ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception(ex.Message, ex);
            }
            catch (OddException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("End");
            }
        }

        static int PositiveAndPar()
        {
            Random random = new Random();
            int value = random.Next(-30, 30);

            if (value < 0)
            {
                Console.WriteLine(value);
                throw new NegativeException();
               
            }

            if (value % 2 == 1)
            {
                Console.WriteLine(value);
                throw new OddException();
                
            }
            return value;
        }
    }
}
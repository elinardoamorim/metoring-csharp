using MetoringCsharp.Challenge.TaxCoupon;
using MetoringCsharp.Fundamentals;
using MetoringCsharp.Collection.Enum;
using ProjetoCSharp;
using System;
using MetoringCsharp.Collection.List;
using MetoringCsharp.Collection.Array;
using MetoringCsharp.Collection.ArrayListPractice;
using MetoringCsharp.Challenge.CheckOlderPerson;
using MetoringCsharp.Challenge.AverageSalary;
using MetoringCsharp.Challenge.Rectangle;
using MetoringCsharp.Fundamentals.Interface;
using MetoringCsharp.Fundamentals.Abstract;
using MetoringCsharp.Fundamentals.ErrorTratament;
using MetoringCsharp.Fundamentals.Inheritance;
using MetoringCsharp.Fundamentals.Heritage;
using MetoringCsharp.Fundamentals.DateETime;
using MentoringCSharp.Fundamentals.Exceptions;
using MetoringCsharp.Fundamentals.Exceptions;
using MetoringCsharp.Challenge.Inventory;
using MetoringCsharp.Challenge.Consultancy;

namespace MetoringCsharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var center = new ExerciseCenter(new Dictionary<string, Action>() {
                {"Calculator - Fundamentals", CalculatorExecute.Execute},
                {"Tax Coupon - Challenge", TaxCouponExecute.Execute},
                {"Enum - Collections", DayWeekExecute.Execute },
                {"List - Collections", BuyListExecute.Execute },
                {"ArrayAverage - Collections", ArrayAverageExecute.Execute },
                {"ArrayList - Collections", AverageExecute.Execute },
                {"Converter Moeda - Fundametals", CurrencyConverter.Execute },
                {"Verificar pessoa velha - Challenge", PersonExecute.Execute },
                {"Média Salarial - Challenge", AverageSalary.Execute },
                {"Retângulo - Challenge", RectangleExecute.Execute },
                {"Implement Interface - Fundamentals", InterfaceExecute.Execute },
                {"Implement Class Abstract - Fundamentals", AbstractExecute.Execute },
                {"Implement Error Tratament - Fundamentals", ErrorTratament.Execute },
                {"Implement Inheritance - Fundamentals", InheritanceExecute.Execute },
                {"Implement Heritage - Fundamentals", HeritageMain.Execute },
                {"Implement DateTime - Fundamentals", DateTimeExecute.Execute },
                {"Implement Exceptions - Fundamentals", ExceptionMain.Execute },
                {"Implement ProductDesafio - Challenge", ProductMain.Execute },
                {"Implement CalculationService - Challenge", CalculationMain.Execute }









            });
            center.SelectAndRun();
            

            
            //var accountCorrent = new AccountCorrent("Gabriel", 0536, 412578, 1200.01);
            //var accountCorrent = new AccountCorrent();
            //AccountDeposit accountDeposit = new AccountDeposit();

            //accountDeposit.balance = 10.0;

            //Console.WriteLine(accountDeposit.balance);
            //Console.WriteLine(accountCorrent.balance);

            //accountCorrent.nameClient = "Gabriel";
            //accountCorrent.agency = 0536;
            //accountCorrent.account = 412578;
            //accountCorrent.balance = 1200.01;

            //Calculator calculator = new Calculator(23, 55);

            //Console.WriteLine(calculator.Result);
            
            //double sum = calculator.Sum(25, 45);
            //Console.WriteLine("Resultado da soma: " + sum);

            //double subtract = calculator.Subtract(25, 45);
            //Console.WriteLine("Resultado da subtração: " + subtract);

            //double multiplication = calculator.Multiplication(25, 45);
            //Console.WriteLine("Resultado da multiplicação: " + multiplication);

            //double division = calculator.Division(25, 45);
            //Console.WriteLine("Resultado da divisão: " + division);


            //calculator.ValueFirst = 15;
            //calculator.ValueSecond = 13;

            //Result = calculator.Sum();
            //Console.WriteLine(Result);



        }
    }
}

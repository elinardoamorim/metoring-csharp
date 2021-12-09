using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals
{
    public class CalculatorExecute
    {
        public static void Execute()
        {
            Calculator calculator = new Calculator();
            bool programFinal = true;

            while (programFinal)
            {
                //Console.WriteLine("Informe qual o sinal da operação aritmética que você quer fazer ou digite" 
                //    + "\n\"exit\" para sair:" 
                //    + "\n\n\"+\" - Soma" 
                //    + "\n\"-\" - Subtração" 
                //    + "\n\"*\" - Multiplicação" 
                //    + "\n\"/\" - Divisão");
                Console.WriteLine("Informe qual o sinal da operação aritmética que você quer fazer ou digite: ");
                Console.WriteLine("\"exit\" para SAIR");
                Console.WriteLine("\"+\" - Soma");
                Console.WriteLine("\"-\" - Subtração");
                Console.WriteLine("\"*\" - Multiplicação");
                Console.WriteLine("\"/\" - Divisão");

                string operatorSignal = Console.ReadLine();

                if (operatorSignal == "exit")
                {
                    programFinal = false;
                }
                else
                {
                    switch (operatorSignal)
                    {
                        case "+":
                            Console.WriteLine("Digite o primeiro valor: ");
                            double valueSumFirst = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Digite o segundo valor: ");
                            double valueSumSecond = Convert.ToDouble(Console.ReadLine());
                            double Sumresult = calculator.Sum(valueSumFirst, valueSumSecond);
                            Console.WriteLine($"Soma dos valores {valueSumFirst} + {valueSumSecond} = {Sumresult}");
                            Console.WriteLine();
                            break;

                        case "-":

                            Console.WriteLine("Digite o primeiro valor: ");
                            double valueSubtractFirst = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Digite o segundo valor: ");
                            double valueSubtractSecond = Convert.ToDouble(Console.ReadLine());
                            double subtractResult = calculator.Subtract(valueSubtractFirst, valueSubtractSecond);
                            Console.WriteLine($"Subtração dos valores {valueSubtractFirst} - {valueSubtractSecond} = {subtractResult}");
                            Console.WriteLine();
                            break;

                        case "*":
                            Console.WriteLine("Digite o primeiro valor: ");
                            double valueMultiplicationFirst = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Digite o segundo valor: ");
                            double valueMultiplicationSecond = Convert.ToDouble(Console.ReadLine());
                            double multiplicationResult = calculator.Multiplication(valueMultiplicationFirst, valueMultiplicationSecond);
                            Console.WriteLine($"Multiplicação dos valores {valueMultiplicationFirst} * {valueMultiplicationSecond} = {multiplicationResult}");
                            Console.WriteLine();
                            break;

                        case "/":
                            Console.WriteLine("Digite o primeiro valor: ");
                            double valueDivisionFirst = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Digite o segundo valor: ");
                            double valueDivisionSecond = Convert.ToDouble(Console.ReadLine());
                            double divisionResult = calculator.Division(valueDivisionFirst, valueDivisionSecond);
                            Console.WriteLine($"Divisão dos valores {valueDivisionFirst} / {valueDivisionSecond} = {divisionResult}");
                            Console.WriteLine();
                            break;

                        default:
                            Console.WriteLine("Operador Invalido");
                            break;
                    }
                }
            }

            Console.WriteLine("Programa finalizado com sucesso!!");

        }
    }
}

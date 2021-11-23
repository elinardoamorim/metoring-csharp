using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Challenge.AverageSalary
{
    public class AverageSalary
    {
        public static void Execute()
        {
            decimal salaryFirst, salarySecond;
            string nameFirst, nameSecond;


            Console.WriteLine("Insira o nome do primeiro funcionário: ");
            nameFirst = Console.ReadLine();

            Console.WriteLine($"Insira o salário do {nameFirst}: ");
            salaryFirst = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Insira o nome do segundo funcionário: ");
            nameSecond = Console.ReadLine();

            Console.WriteLine($"Insira o salário do {nameFirst}: ");
            salarySecond = Convert.ToDecimal(Console.ReadLine());

            decimal averageSalary = (salaryFirst + salarySecond) / 2;

            Console.WriteLine();
            Console.WriteLine($"Média salarial é R$ {averageSalary.ToString("N2")}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals.Interface
{
    public class InterfaceExecute
    {
        public static void Execute()
        {
            Employee employee = new Employee();

            employee.name = "Felipe";
            employee.salary = 2500.00;

            Console.WriteLine("Antes do reajuste");
            Console.WriteLine($"Funcionário: {employee.name}");
            Console.WriteLine($"Sálario: {employee.salary}");

            employee.CalculatorReajustment();

            Console.WriteLine("\nDepois do Reajuste");
            Console.WriteLine($"Funcionário: {employee.name}");
            Console.WriteLine($"Sálario: {employee.salary}");


            Console.ReadKey();
        }
    }
}

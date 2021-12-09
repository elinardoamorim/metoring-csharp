using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals.Interface
{
    public class Employee : IReadjustmentSalary
    {
        public string name;
        public double salary;

        public void CalculatorReajustment()
        {
            salary = salary * 1.50;
        }
    }
}

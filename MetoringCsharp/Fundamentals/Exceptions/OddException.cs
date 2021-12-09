using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentoringCSharp.Fundamentals.Exceptions
{
    public class OddException : ArithmeticException
    {
        public OddException() : base("The number is odd.")
        {
            
        }
    }
}
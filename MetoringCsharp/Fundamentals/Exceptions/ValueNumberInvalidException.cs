using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals.Exceptions
{
    public class ValueNumberInvalidException : FormatException
    {
        public ValueNumberInvalidException() : base("Valor inserido inválido, digite apenas números") { }

        public ValueNumberInvalidException(string message) : base(message) { }
    }
}

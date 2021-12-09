using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals
{
    public class CurrencyConverter
    {
        public static void Execute()
        {
            decimal quotation, amountDolar;

            Console.WriteLine("Quantos dolares você vai querer? ");
            amountDolar = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine("Qual a cotação do dia? ");
            quotation = Convert.ToDecimal(Console.ReadLine());

            decimal convert = amountDolar * quotation;

            Console.WriteLine($"Para você receber {amountDolar} dolares, terá que pagar R$ {ConvertCoin(convert).ToString("N2")} em reais");
        }

        public static decimal ConvertCoin(decimal convert)
        {
            return convert + ((convert * 6) / 100);
        }
    }

}

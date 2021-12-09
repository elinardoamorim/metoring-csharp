using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals.DateETime
{
    public class DateTimeExecute
    {
        public static void Execute()
        {
            TimeDate timeDate = new TimeDate();

            Console.WriteLine(timeDate.CheckMonth(DateTime.Now.Month));
            Console.WriteLine(timeDate.ReturnMonth(DateTime.Now.Month));

            var previousMonth = DateTime.Now.Month - 1 > 0 ? DateTime.Now.Month - 1 : 12;
            var nextMonth = DateTime.Now.Month + 1 <= 12 ? DateTime.Now.Month + 1 : 1;

            Console.WriteLine(timeDate.ReturnMonth(previousMonth));
            Console.WriteLine(timeDate.ReturnMonth(nextMonth));


            //TimeSpan

            TimeSpan tsInstance = new TimeSpan();
            Console.WriteLine(tsInstance);

            TimeSpan tsInstance1 = new TimeSpan(1);
            Console.WriteLine(tsInstance1);

            TimeSpan tsInstance2 = new TimeSpan(7, 36, 10);
            Console.WriteLine(tsInstance2);

            TimeSpan tsInstance3 = new TimeSpan(8, 2, 50, 10);
            Console.WriteLine(tsInstance3);
            
            //tsInstance3 != tsInstance4 = 19, 13, 59, 900

            TimeSpan tsInstance4 = new TimeSpan(4, 7, 36, 10, 100);
            Console.WriteLine(tsInstance4);

            TimeDate.ShowProprerties(tsInstance3, tsInstance4);

            Console.WriteLine("Hora Atual : " + tsInstance.Hours);
            var tsOneHour = new TimeSpan(1, 0, 0);
            tsInstance = tsInstance.Add(tsOneHour);
            Console.WriteLine("Hora após Add : " + tsInstance.Hours);

            var parse = TimeSpan.Parse("23:59:59.999");
            Console.WriteLine("O Parse Tranformou de String (23:59:59.999) para TimeSpan Ficando {0}:{1}:{2}.{3}", parse.Hours, parse.Minutes, 
                parse.Seconds, parse.Milliseconds);



            Console.ReadKey();
        }
    }
}

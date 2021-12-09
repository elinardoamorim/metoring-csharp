using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.Enum
{
    public class DayWeekExecute
    {
        public static void Execute()
        {
            DayWeek day = new DayWeek();

            DayWeek daySegunda = new DayWeek();

            day.ValidDay(DayWeek.WeekDay.SEGUNDA);

            Console.WriteLine(daySegunda.Domingo(DayWeek.WeekDay.DOMINGO));



            Day dia = Day.domingo;
            Console.WriteLine(dia);
            dia = Day.terça;
            Console.WriteLine(dia);

            Console.ReadKey();
            
        }
    }

    enum Day { domingo, terça};
}

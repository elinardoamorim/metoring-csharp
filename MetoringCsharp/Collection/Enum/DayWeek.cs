using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.Enum
{
    public class DayWeek
    {
        

        public void ValidDay(WeekDay day)
        {
            if(day == WeekDay.SEGUNDA)
            {
                Console.WriteLine("Hoje é segunda");
            }
            else
            {
                Console.WriteLine("Hoje não é segunda");
            }
        }
        public string Domingo(WeekDay day)
        {
           if(WeekDay.DOMINGO == day)
            {
                return $"Hoje é {WeekDay.DOMINGO}";
            } 
            else
            {
                return $"Hoje não é {WeekDay.DOMINGO}";
            }
        }

        public enum WeekDay { DOMINGO, SEGUNDA, TERÇA, QUARTA, QUINTA, SEXTA, SÁBADO }

    }
}

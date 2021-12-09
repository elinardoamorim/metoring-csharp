using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals.DateETime
{
    public class TimeDate
    {
        public int CheckMonth(int month)
        {
            int result = 0;

            switch (month)
            {
                case 1:
                    result = 31;
                    break;
                case 2:
                    result = DateTime.IsLeapYear(DateTime.Now.Year) ? 29 : 28;
                    break;
                case 3:
                    result = 31;
                    break;
                case 4:
                    result = 30;
                    break;
                case 5:
                    result = 31;
                    break;
                case 6:
                    result = 30;
                    break;
                case 7:
                    result = 31;
                    break;
                case 8:
                    result = 31;
                    break;
                case 9:
                    result = 30;
                    break;
                case 10:
                    result = 31;
                    break;
                case 11:
                    result = 30;
                    break;
                case 12:
                    result = 31;
                    break;
            }
            return result;
        }

        public string ReturnMonth(int month)
        {
            string result = string.Empty;

            switch (month)
            {
                case 1:
                    result = "Janeiro";
                    break;
                case 2:
                    result = "Fevereiro";
                    break;
                case 3:
                    result = "Março";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Maio";
                    break;
                case 6:
                    result = "Junho";
                    break;
                case 7:
                    result = "Julho";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Setembro";
                    break;
                case 10:
                    result = "Outubro";
                    break;
                case 11:
                    result = "Novembro";
                    break;
                case 12:
                    result = "Dezembro";
                    break;
            }

            return result;
        }

        public static void ShowProprerties(TimeSpan timeZoneBR, TimeSpan timeZoneUS)
        {
            TimeSpan intervalo = timeZoneBR - timeZoneUS;

            Console.WriteLine("Dias: " + intervalo.Days);
            Console.WriteLine("Horas: " + intervalo.Hours);
            Console.WriteLine("Minutos: " + intervalo.Minutes);
            Console.WriteLine("Segundos: " + intervalo.Seconds);
            Console.WriteLine("Milissegundos: " + intervalo.Milliseconds);
            Console.WriteLine("Ticks: " + intervalo.Ticks);
            Console.WriteLine("Total de Dias: " + intervalo.TotalDays);
            Console.WriteLine("Total de Horas: " + intervalo.TotalHours);
            Console.WriteLine("Total de Minutos: " + intervalo.TotalMinutes);
            Console.WriteLine("Total de Segundos: " + intervalo.TotalSeconds);
            Console.WriteLine("Total de Milissegundos: " + intervalo.TotalMilliseconds);
        }

    }
}

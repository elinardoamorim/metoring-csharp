using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.ArrayListPractice
{
    public class AverageExecute
    {
        public static void Execute()
        {
            bool programFinal = true;
            Decimal totalAverage = 0;
            bool noteFirst = true;

            ArrayList averageList = new ArrayList();

            do
            {
                if(noteFirst)
                {
                    Console.WriteLine("Insira a primeira nota: ");
                    Decimal note = Decimal.Parse(Console.ReadLine());
                    AverageList notes = new AverageList(note);
                    averageList.Add(notes);                  
                    noteFirst = false;
                } 
                else
                {
                    Console.WriteLine("Deseja inserir mais uma nota? Digite \"Sim\" para continuar ou \"Exit\" para sair");
                    string programNoOrYes = Console.ReadLine();
                    if(programNoOrYes == "exit" || programNoOrYes == "Exit" || programNoOrYes == "EXIT")
                    {
                        programFinal = false;
                    } 
                    else if(programNoOrYes == "Sim" || programNoOrYes == "sim" || programNoOrYes == "SIM")
                    {
                        Console.WriteLine("Insira mais uma nota: ");
                        decimal note = Decimal.Parse(Console.ReadLine());
                        AverageList notes = new AverageList(note);
                        averageList.Add(notes);
                    }
                }
            }
            while (programFinal);

            foreach(AverageList notes in averageList)
            {
                Console.WriteLine(notes.Note);
            }
        }
    }
}

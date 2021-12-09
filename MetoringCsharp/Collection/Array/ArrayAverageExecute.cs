using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.Array
{
    public class ArrayAverageExecute
    {
        public static void Execute()
        {
            bool isEmpty;

            ArrayAverage averageArray = new ArrayAverage(10);

            averageArray.Average[0] = 1.0m;
            averageArray.Average[1] = 2.0m;

            Console.WriteLine("Digite o index que quer inserir o valor: ");
            int setIndex = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o valor que quer inserir: ");
            decimal setValue = Convert.ToDecimal(Console.ReadLine());

            if (averageArray.AddArray(setIndex)){
                averageArray.Average[setIndex] = setValue;
                Console.WriteLine($"O valor {setValue} foi adicionado ao index {setIndex}");
            } 
            else
            {
                Console.WriteLine("Index esta ocupado");
            }

            foreach (decimal array in averageArray.Average)
            {
                Console.WriteLine(array);
            }

        }
    }
}

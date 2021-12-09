using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.Array
{
    public class ArrayAverage
    {
        public decimal [] Average { get; set; }
        public bool IsEmpty { get; set; }

        public ArrayAverage(int amount)
        {
            Average = new decimal[amount];
        }

        public bool AddArray(int indexArray)
        {
            if(Average[indexArray] == 0)
            {
                IsEmpty = true;
            } 
            else
            {
                IsEmpty = false;
            }
            
            return IsEmpty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Challenge.Consultancy
{
    public class CalculationService
    {
        public static Product Max(List<Product> list)
        {
            Product product = new Product();

            for (int index = 0; index < list.Count; index++)
            {
                if (list[index].Price > product.Price)
                {
                    product = list[index];
                }
            }

            return product;
        }
    }
}

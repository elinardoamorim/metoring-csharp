using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Challenge.Consultancy
{
    public  class CalculationMain
    {
        public static void Execute()
        {
            int amountProducts;

            Console.WriteLine("Digite quantos produtos deseja verificar: ");
            amountProducts = Convert.ToInt32(Console.ReadLine());

            List<Product> products = new List<Product>();

            for (int i = 0; i < amountProducts; i++)
            {
                Console.WriteLine();
                Console.Write("Digite o nome do produto: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Digite o valor do produto: ");
                double priceProduct = Convert.ToDouble(Console.ReadLine());

                products.Add(new Product(name: nameProduct, price: priceProduct));
            }

            Console.WriteLine();
            Console.WriteLine("Max:");
            Console.WriteLine(CalculationService.Max(products));
        }
    }
}

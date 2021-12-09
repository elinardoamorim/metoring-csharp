using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Challenge.Inventory
{
    public class ProductMain
    {
       public static void Execute()
        {
            bool programFinal = true;
            string optionProgram;
            double totalPrice = 0;
            int amount;

            Product tvProduct = new Product(name: "TV LG", price: 900.00, amount: 10);

            totalPrice = tvProduct.Price * tvProduct.Amount;

            Console.WriteLine($"Dados do Produto: {tvProduct}");
            Console.WriteLine();

            while (programFinal)
            {
                Console.WriteLine("Digite a operação que quer realizar: \n\"1\" - Adicionar Produto" +
                    "\n\"2\" - Remover Produto" +
                    "\n\"3\" - Finalizar Programa");
                optionProgram = Console.ReadLine();

                if (optionProgram.Equals("3"))
                {
                    Console.Write("Digite a quantidade produtos a ser adicionado ao estoque: ");
                    amount = Convert.ToInt32(Console.ReadLine());

                    tvProduct.AddProduct(amount);

                    totalPrice = (tvProduct.Price * tvProduct.Amount);

                    Console.WriteLine($"Dados Atualizado: {tvProduct}");
                    Console.WriteLine();

                } 
                else if (optionProgram.Equals("2"))
                {
                    Console.Write("Digite a quantidade de produtos a ser removido do estoque: ");
                    amount = Convert.ToInt32((Console.ReadLine()));

                    tvProduct.RemoveProduct(amount);

                    totalPrice = tvProduct.Price * tvProduct.Amount;

                    Console.WriteLine($"Dados Atualizado: {tvProduct}");
                    Console.WriteLine();
                } 
                else if (optionProgram.Equals("3"))
                {
                    programFinal = false;
                }
            }
        }
        
      
    }
}

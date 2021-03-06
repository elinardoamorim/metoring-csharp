using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Challenge.TaxCoupon
{
    public class TaxCouponExecute
    {
        public static void Execute()
        {

            List<ItemProducts> itemsProducts = new List<ItemProducts>();

            string nameProduct;
            decimal price, discount, amount;
            bool programFinal = true;
            decimal totalPrice = 0;

            do
            {
                Console.WriteLine("Deseja continua inserindo produtos? Digite: \"Sim\" para CONTINUAR ou \"Exit\" para SAIR");
                string programYesOrExit = Console.ReadLine();
                Console.WriteLine();

                if (programYesOrExit.ToLower() == "sim")
                {
                    Console.WriteLine("Digite nome do produto: ");
                    nameProduct = Console.ReadLine();

                    Console.WriteLine("Digite o valor do produto: ");
                    price = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Digite % de desconto do produto: ");
                    discount = Convert.ToDecimal(Console.ReadLine());

                    Console.WriteLine("Digite a quantide do produto: ");
                    amount = Convert.ToDecimal(Console.ReadLine());

                    Product product = new Product(name: nameProduct, price: price, discount: discount);

                    ItemProducts itemProduct = new ItemProducts()
                    {
                        Product = product,
                        amount = amount
                    };

                    itemsProducts.Add(itemProduct);
                    //itemProduct.AddProduct(nameProduct, price, discount, amount)
                }
                else if (programYesOrExit.ToUpper() == "EXIT")
                {
                    programFinal = false;
                }

            }
            while (programFinal);

            //foreach (ItemProducts itemProduct in itemsProducts)
            //{
            //    Console.WriteLine($"Produto: {itemProduct.Product.Name} " +
            //    $"\nPreço/Unidade: {itemProduct.Product.Price}" +
            //    $"\nQuantidade: {itemProduct.amount}" +
            //    $"\nValor total com desconto: {itemProduct.TotalPrice(itemProduct.Product.Price, itemProduct.Product.Discount, itemProduct.amount).ToString("N2")}");
            //    Console.WriteLine();

            //    totalPrice += itemProduct.TotalPrice(itemProduct.Product.Price, itemProduct.Product.Discount, itemProduct.amount);
            //}

            itemsProducts.ForEach(itemProduct =>
            {
                Console.WriteLine($"Produto: {itemProduct.Product.Name} " +
                $"\nPreço/Unidade: {itemProduct.Product.Price}" +
                $"\nQuantidade: {itemProduct.amount}" +
                $"\nValor total com desconto: {itemProduct.TotalPrice(itemProduct.Product.Price, itemProduct.Product.Discount, itemProduct.amount).ToString("N2")}");
                Console.WriteLine();

                totalPrice += itemProduct.TotalPrice(itemProduct.Product.Price, itemProduct.Product.Discount, itemProduct.amount);
            });

            Console.WriteLine($"Valor total da compra com desconto: {totalPrice.ToString("N2")}");
        }
    }
}

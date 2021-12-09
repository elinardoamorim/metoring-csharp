using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.List
{
    public class BuyListExecute
    {
        public static void Execute()
        {
            

            //Objetos de Produtos
            Products arroz = new Products("Arroz");
            Products feijao = new Products("Feijão");
            Products macarrao = new Products("Macarrão");

            Console.WriteLine($"Produto: {arroz}");

            //Objetos de Buylist
            BuyItemList listProductOne= new BuyItemList(arroz, 15);
            BuyItemList listProductTwo = new BuyItemList(feijao, 5);
            BuyItemList listProductThree = new BuyItemList(macarrao, 5);

            Console.WriteLine($"Lista {listProductOne}\n");

            //Lista
            List<BuyItemList> buyList = new List<BuyItemList>();

            buyList.Add(listProductOne);
            buyList.Add(listProductTwo);
            buyList.Add(listProductThree);


            Console.WriteLine($"Nome Produto: {buyList[0].Product} \nQuantidade: {buyList[0].Amount}\n");
            Console.WriteLine($"Nome Produto: {buyList[1].Product} \nQuantidade: {buyList[1].Amount}\n");
            Console.WriteLine($"Nome Produto: {buyList[2].Product} \nQuantidade: {buyList[2].Amount}\n");

            Console.WriteLine($"Tamanho da lista: {buyList.Count} produtos");

            foreach (BuyItemList item in buyList)
            {
                Console.WriteLine($"{item}\n");
            }

            //buyList.Remove(buyList[1]);
            //buyList.Remove(buyList[2]);
            Console.WriteLine("Delete");
            //buyList.RemoveRange(0, 2);
            //buyList.RemoveAt(0);

            Console.WriteLine($"GET {buyList.IndexOf(buyList[1])}");


            buyList[0].Amount = 0;

            foreach (BuyItemList item in buyList)
            {
                Console.WriteLine($"{item}");
            }


            Console.ReadKey();
        }
    }
}

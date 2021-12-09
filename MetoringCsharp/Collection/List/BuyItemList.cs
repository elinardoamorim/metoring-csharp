using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Collection.List
{
    public class BuyItemList
    {
        public Products Product { get; set; }
        public int Amount { get; set; }

        public BuyItemList(Products product, int amount)
        {
            Product = product;
            Amount = amount;
        }

        public BuyItemList()
        {

        }

        public override string ToString()
        {
            return $"Produto: {Product} \nQuantidade: {Amount}";
        }
    }
}

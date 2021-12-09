using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetoringCsharp.Fundamentals
{
    public class AccountCorrent
    {
        public string nameClient;
        public int agency;
        public int account;
        public double balance;

        //totalBalance multiplicar pela quantidade x balance usando get
        private double totalBalance { get; set; }
        public double amount  { get; set; }

        public AccountCorrent(string nameClient, int agency, int account, double balance)
        {
            this.nameClient = nameClient;
            this.agency = agency;
            this.account = account;
            this.balance = balance;
        } 

        public AccountCorrent()
        {

        }
        
        
        public override String ToString()
        {
            String result = "Nome do Cliente: " + nameClient
                + "\nAgência: " + agency + "\nConta: " + account
                + "\nSaldo: " + balance;
            
            return result;
        }
    }
}

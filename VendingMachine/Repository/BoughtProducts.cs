using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Repo
{
    public class BoughtProducts
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public BoughtProducts(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;


namespace VendingMachine.Repo
{ 
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Stock { get; set; }
        public Product(string code, string name, double value, int stock)
        {
            Code = code;
            Name = name;
            Value = value;
            Stock = stock;
        }
    }

}

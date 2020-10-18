using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace VendingMachine.Repo
{

    public interface IReadFromFile
    {
        List<Product> LoadProducts();
        List<Product> GetProducts();
    }
    public class ReadFromFile : IReadFromFile
    {
        public string[] productsList = File.ReadAllLines(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "List_Of_Products.txt"));

        public List<Product> products = new List<Product>();

        public ReadFromFile()
        {

        }

        public List<Product> LoadProducts()
        {
            products.AddRange(from string products in productsList
                              let product = products.Split(';')
                              let newProduct = new Product(product[0].ToString(), product[1].ToString(), Int32.Parse(product[2]), Int32.Parse(product[3]))
                              select newProduct);
            return products;
        }

        public List<Product> GetProducts()
        {
            return products;
        }
    }
}

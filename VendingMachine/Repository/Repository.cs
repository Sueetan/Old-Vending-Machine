using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;


namespace VendingMachine.Repo
{
    public interface IRepository
    {
        void RemoveProduct(string code);
        int CountProducts();
        Product GetProduct(string name, ref double value, ref int stock);
        void AddProduct(Product product);
        List<Product> GetAllProducts();
        void ModifyProduct(Product product);
        void Bought(Product product);
        List<BoughtProducts> GetAllBoughtProducts();

    }
    public class Repository : IRepository
    {
        public List<Product> products = new List<Product>();
        public List<BoughtProducts> boughtproducts = new List<BoughtProducts>();

        public IReadFromFile readFromFile;
        public Repository(IReadFromFile readFromFile)
        {
            this.readFromFile = readFromFile;
            products = readFromFile.LoadProducts();
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(string code)
        {
            bool item_found = false;
            foreach (var product in from Product product in products
                                    where code == product.Code.ToLower()
                                    select product)
            {
                products.Remove(product);
                item_found = true;
                break;
            }

            if (item_found == false)
            {
                Console.WriteLine("Item not found!");
            }
        }

        public int CountProducts()
        {
            return products.Count;
        }


        public Product GetProduct(string name, ref double value, ref int stock)
        {
            bool item_found = false;
            string code;
            foreach (var product in from Product product in products
                                    where name == product.Name.ToLower()
                                    select product)
            {
                code = product.Code;
                value = product.Value;
                stock = product.Stock;
                item_found = true;
                Product produs = new Product(code, name, value, stock);
                return produs;
            }
            if (item_found == false)
            {
                Console.WriteLine("Item not found!");
                return new Product("", "", 0, 0);
            }
            return new Product("", "", 0, 0);
        }

        public List<BoughtProducts> GetAllBoughtProducts()
        {
            return boughtproducts;
        }

        public void Bought(Product product)
        {
            bool boughtExist = false;
            List<BoughtProducts> boughtP = GetAllBoughtProducts();

            foreach (BoughtProducts bought in boughtP)
            {
                if(bought.Name == product.Name)
                {
                    bought.Quantity++;
                    boughtExist = true;
                }
            }

            if(!boughtExist)
            {
                BoughtProducts newBought = new BoughtProducts(product.Name, 1);
                boughtproducts.Add(newBought);
            }
        }
        public void ModifyProduct(Product newproduct)
        {
            List<Product> products = GetAllProducts();
            foreach (Product product in products)
            {
                if (product.Code.ToLower() == newproduct.Code.ToLower())
                {
                    product.Name = newproduct.Name;
                    product.Value = newproduct.Value;
                    product.Stock = newproduct.Stock;
                }
            }
        }

    }
}

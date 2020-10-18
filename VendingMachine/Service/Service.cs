using System;
using System.Collections.Generic;
using System.Text;

using VendingMachine.Repo;

namespace VendingMachine.Servicee
{
    public interface IService
    {
        void LoadProducts();
        List<Product> GetProducts();
        List<BoughtProducts> GetBoughts();
        void AddNewProduct(string code, string name, double value, int stock);
        void RemoveProduct(string code);
        int CountProducts();
        void GetProduct(string name, ref double value, ref int stock);
        int BuyProduct(string code);

    }
    public class Service:IService
    {
        IRepository repository;
        public Service(IRepository repository)
        {
            this.repository = repository;
        }

        public void LoadProducts()
        {
   
        }
        public List<BoughtProducts> GetBoughts()
        {
            return repository.GetAllBoughtProducts();
        }
        public List<Product> GetProducts()
        {
            return repository.GetAllProducts();
        }

        public void AddNewProduct(string code, string name, double value, int stock)
        {
            Product product = new Product(code, name, value, stock);

            repository.AddProduct(product);
        }

        public void RemoveProduct(string code)
        {
            string lower_case_code = code.ToLower();

            repository.RemoveProduct(lower_case_code);
        }

        public int CountProducts()
        {
            int count_products;

            count_products = repository.CountProducts();

            return count_products;
        }

        public void GetProduct(string name, ref double value, ref int stock)
        {
            string lower_case_name = name.ToLower();

            repository.GetProduct(lower_case_name, ref value, ref stock);
        }

        public int BuyProduct(string code)
        {
            List<Product> products = GetProducts();

            foreach (Product product in products)
            {
                if (product.Code == code)
                {
                    Product boughtProduct = new Product(code, product.Name, product.Value, product.Stock -1);

                    repository.Bought(boughtProduct);
                    repository.ModifyProduct(boughtProduct);

                    return 1;
                }
            }
            return 0;
        }
    }
}

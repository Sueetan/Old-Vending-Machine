using System;
using System.Collections.Generic;
using System.Text;

using VendingMachine.Repo;
using VendingMachine.Servicee;


namespace VendingMachine
{

    class UI
    {
        
        IService service;

        public UI(IService service)
        {
            this.service = service;
        }

        public void MainMenu()
        {
            bool showMenu = true;
            MainMenuInterface();
            while (showMenu)
            {
                string command_typed = Console.ReadLine();
                
                if (command_typed == "0")
                {
                    showMenu = false;
                }
                if (command_typed == "1")
                {
                    ClientMenu();
                    showMenu = false;
                }
                if (command_typed == "2")
                {
                    AdminMenu();
                    showMenu = false;
                }
            }
        }

        public void MainMenuInterface()
        {
            Console.WriteLine("Welcome to Vending Machine\n");
            Console.WriteLine("Type '0' to exit from Machine\n");
            Console.WriteLine("Type '1' to enter on Client Menu\n");
            Console.WriteLine("Type '2' to enter on Admin Menu\n");
        }

        public void ClientMenu()
        {
            bool showMenu = true;

            ShowClientMenuInterface();

            while (showMenu)
            {
                showMenu = ClientMainMenu();
            }
        }

        public void ShowClientMenuInterface()
        {
            Console.WriteLine("Welcome to my Vending Machine\n");
            Console.WriteLine("1 - To see all the products");
            Console.WriteLine("2 - To buy a product");
            Console.WriteLine("5 - To get a product");
            Console.WriteLine("6 - Most bought Products");
            Console.WriteLine("e - To exit from machine\n");
        }

        public bool ClientMainMenu()
        {
            string userChoise = Console.ReadLine();

            switch (userChoise)
            {
                case "1":
                    ListProducts();
                    BackMessage();
                    return true;

                case "2":
                    BuyProduct();
                    BackMessage();
                    return true;
                case "5":
                    GetProduct();
                    BackMessage();
                    return true;

                case "6":
                    MostBoughtProducts();
                    BackMessage();
                    return true;

                case "e":
                    return false;

                case "b":
                    ShowClientMenuInterface();
                    return true;

                default:
                    return true;
            }
        }

        public void AdminMenu()
        {
            bool showMenu = true;

            ShowAdminMenuInterface();

            while (showMenu)
            {
                showMenu = AdminMainMenu();
            }
        }

        public void ShowAdminMenuInterface()
        {
            Console.WriteLine("Welcome to my Vending Machine\n");
            Console.WriteLine("1 - To see all the products");
            Console.WriteLine("2 - To add a product");
            Console.WriteLine("3 - To remove a product");
            Console.WriteLine("4 - To count the products");
            Console.WriteLine("5 - To get a product");
            Console.WriteLine("6 - Most bought Products");
            Console.WriteLine("e - To exit from machine\n");

        }

        public bool AdminMainMenu()
        {
            string userChoise = Console.ReadLine(); 

            switch (userChoise)
            {
                case "1":
                    ListProducts();
                    BackMessage();
                    return true;

                case "2":
                    AddNewProduct();
                    BackMessage();
                    return true;

                case "3":
                    RemoveProduct();
                    BackMessage();
                    return true;

                case "4":
                    CountProducts();
                    BackMessage();
                    return true;

                case "5":
                    GetProduct();
                    BackMessage();
                    return true;

                case "6":
                    MostBoughtProducts();
                    BackMessage();
                    return true;

                case "e":       
                    return false;

                case "b":
                    ShowAdminMenuInterface();
                    return true;

                default:
                    return true;
            }
        }

        private void BackMessage()
        {
            Console.Write("\r\nPress 'b' to show to Main Menu\n");
        }
        public void ListProducts()
        {
            List<Product> products = new List<Product>();

            products = service.GetProducts();

            foreach (Product product in products)
            {
                Console.WriteLine("Code:{0} Product: {1} have the price: {2} lei, and a stock of: {3}", product.Code,product.Name, product.Value, product.Stock);
            }
        }

        public void BuyProduct()
        {
            string code;

            Console.Write("Enter the Code of the product you want to buy:");
            code = Console.ReadLine();
            

            if(service.BuyProduct(code) == 1)
            {
                Console.WriteLine("Item purchased");
            }
            else
            {
                Console.WriteLine("Item not purchased");
            }
        }

        public void AddNewProduct()
        {
            string code,name;
            double value;
            int stock;

            Console.Write("Enter the code of the product: ");
            code = Console.ReadLine();

            Console.Write("Enter the name of the product: ");
            name = Console.ReadLine();

            Console.Write("Enter the value of the product: ");
            value = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the stock of the product: ");
            stock = Convert.ToInt32(Console.ReadLine());

            service.AddNewProduct(code,name, value, stock);
        }

        public void RemoveProduct()
        {
            string code;

            Console.Write("Enter the code of the product you want to remove:");
            code = Console.ReadLine();

            service.RemoveProduct(code);
        }

        public void CountProducts()
        {
            int countproducts;

            countproducts = service.CountProducts();

            Console.WriteLine("The number of products is: {0} ", countproducts);
        }

        public void GetProduct()
        {
            string name;
            double value = 0;
            int stock = 0;

            Console.Write("Enter the name of the product you want to get details: ");

            name = Console.ReadLine();

            service.GetProduct(name,ref value, ref stock);

            Console.WriteLine("Product: {0} have the price: {1} lei, and a stock of: {2}", name, value, stock);
        }
        public void MostBoughtProducts()
        {
            List<BoughtProducts> boughtProducts = service.GetBoughts();

            foreach (BoughtProducts product in boughtProducts)
            {
                Console.WriteLine("Name:{0} Quantity: {1} ", product.Name, product.Quantity);
            }
        }
    }
}

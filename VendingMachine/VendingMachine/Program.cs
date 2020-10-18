using System;
using VendingMachine.Repo;
using VendingMachine.Servicee;

namespace VendingMachine
{
    class Program
    {
        public static void Main()
        {
            ReadFromFile read = new ReadFromFile();
            Repository repo = new Repository(read);
            Service service = new Service(repo);
            UI ui = new UI(service);

            ui.MainMenu();
        }
    }
}
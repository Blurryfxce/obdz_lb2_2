using System;
using System.Linq;
using obdz_lb2_2;
using obdz_lb2_2.Models;

class Program
{
    
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Select an option:");
            Console.WriteLine("1 - Display all data");
            Console.WriteLine("2 - Add sample data to the tables");
            Console.WriteLine("0 - Exit");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    App.DisplayAllData();
                    break;
                case "2":
                    App.AddSampleData();
                    Console.WriteLine("Data added successfully.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

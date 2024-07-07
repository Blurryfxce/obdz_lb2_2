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
            Console.WriteLine("3 - Add new data to Theater");
            Console.WriteLine("4 - Delete Theater");
            Console.WriteLine("5 - Cascade deleting Theater with Screens");
            Console.WriteLine("6 - Update Theater");
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
                case "3":
                    Console.Write("Enter theater name: ");
                    var name = Console.ReadLine();
                    Console.Write("Enter theater address: ");
                    var address = Console.ReadLine();
                    Console.Write("Enter theater phone: ");
                    var phone = Console.ReadLine();
                    App.AddNewTheater(name, address, phone);
                    break;
                case "4":
                    Console.Write("Enter theater ID to delete: ");
                    var theaterId = int.Parse(Console.ReadLine());
                    App.DeleteTheater(theaterId);
                    break;
                case "5":
                    Console.Write("Enter theater ID to delete with screens: ");
                    var theaterIdToDelete = int.Parse(Console.ReadLine());
                    App.DeleteTheaterWithScreens(theaterIdToDelete);
                    break;
                case "6":
                    Console.Write("Enter theater ID to update: ");
                    var theaterIdToUpdate = int.Parse(Console.ReadLine());
                    Console.Write("Enter new theater name: ");
                    var newName = Console.ReadLine();
                    Console.Write("Enter new theater address: ");
                    var newAddress = Console.ReadLine();
                    Console.Write("Enter new theater phone: ");
                    var newPhone = Console.ReadLine();
                    App.UpdateTheater(theaterIdToUpdate, newName, newAddress, newPhone);
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

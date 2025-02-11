using System;

namespace BuffTeksApartment
{
    public class Program
    {
        static void Main(string[] args)
        {
            ResidentManager residentManager = new ResidentManager();
            var residents = residentManager.GetResidents();

            Console.WriteLine("Resident List:");
            foreach (var resident in residents)
            {
                Console.WriteLine($"Name: {resident.Name}, Email: {resident.Email}, Unit: {resident.UnitNumber}");
            }

            PackageManager manager = new PackageManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Welcome to BuffTeksApartment Package Management System!");
                Console.WriteLine("1. Add Package");
                Console.WriteLine("2. Remove Package");
                Console.WriteLine("3. Add Unknown Package");
                Console.WriteLine("4. Mark Package as Picked Up");
                Console.WriteLine("5. Retrieve Package History");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter Resident Name: ");
                        string? residentName = Console.ReadLine();
                        Console.Write("Enter Postal Service: ");
                        string? postalService = Console.ReadLine();
                        Console.Write("Enter Delivery Date (yyyy-mm-dd): ");
                        string? dateInput = Console.ReadLine();
                        if (DateTime.TryParse(dateInput, out DateTime deliveryDate) && residentName != null && postalService != null)
                        {
                            manager.AddPackage(residentName, postalService, deliveryDate);
                            Console.WriteLine("Package added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                        break;
                    case "2":
                        Console.Write("Enter Resident Name to remove package: ");
                        residentName = Console.ReadLine();
                        if (residentName != null)
                        {
                            manager.RemovePackage(residentName);
                            Console.WriteLine("Package removed successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter Owner Name: ");
                        string? ownerName = Console.ReadLine();
                        Console.Write("Enter Postal Service: ");
                        postalService = Console.ReadLine();
                        Console.Write("Enter Delivery Date (yyyy-mm-dd): ");
                        dateInput = Console.ReadLine();
                        if (DateTime.TryParse(dateInput, out deliveryDate) && ownerName != null && postalService != null)
                        {
                            manager.AddUnknownPackage(ownerName, postalService, deliveryDate);
                            Console.WriteLine("Unknown package added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                        break;
                    case "4":
                        Console.Write("Enter Resident Name: ");
                        residentName = Console.ReadLine();
                        Console.Write("Enter Delivery Date (yyyy-mm-dd): ");
                        dateInput = Console.ReadLine();
                        if (DateTime.TryParse(dateInput, out deliveryDate) && residentName != null)
                        {
                            manager.MarkPackageAsPickedUp(residentName, deliveryDate);
                            Console.WriteLine("Package marked as picked up.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                        break;
                    case "5":
                        Console.Write("Enter Unit Number: ");
                        string? unitNumber = Console.ReadLine();
                        Console.Write("Enter Resident Name: ");
                        residentName = Console.ReadLine();
                        if (unitNumber != null && residentName != null)
                        {
                            var history = manager.GetPackageHistory(unitNumber, residentName);
                            Console.WriteLine("Package History:");
                            foreach (var package in history)
                            {
                                Console.WriteLine($"Resident: {package.ResidentName}, Service: {package.PostalService}, Date: {package.DeliveryDate}, Picked Up: {package.IsPickedUp}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please try again.");
                        }
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}

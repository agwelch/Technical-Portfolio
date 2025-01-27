using System;
using System.Collections.Generic;


public class Program
{
    static List<Room> room_list = new List<Room>();
    static string username = "avery";
    static string password = "avery123";
    static void Main()
    {
        InitializeRooms();
        Console.WriteLine("----- CIDM2315 Final Project: Avery Welch ----- \n ----- Welcome to Buff Hotel -----");
        UserLogin();
    }


    static void InitializeRooms()
    {
        for (int i = 101; i <= 110; i++)
        {
            room_list.Add(new Room { Number = i, Capacity = i <= 105 ? 2 : i <= 109 ? 3 : 4, IsAvailable = true });
        }
    }
              
      

      
    static void UserLogin()
    {
        Console.Write("--> Please input username: ");
        string inputUsername = Console.ReadLine();
        Console.Write("--> Please input password: ");
        string inputPassword = Console.ReadLine();
    
      if (inputUsername == username && inputPassword == password)

      {
          bool continueMenu = true;
          while (continueMenu)
          {
              continueMenu = ShowMainMenu();
          }
        }

      else
      {
          Console.WriteLine("Wrong Username/Password");
      }

      static bool ShowMainMenu()
      {
          Console.WriteLine($"*******************");
        Console.WriteLine("--> Please select:");
          Console.WriteLine("1. Show Available Rooms");
          Console.WriteLine("2. Check-In");
          Console.WriteLine("3. Show Reserved Rooms");
          Console.WriteLine("4. Check-Out");
          Console.WriteLine("5. Log Out");
         Console.WriteLine("*******************");

       
          int choice = Convert.ToInt32(Console.ReadLine());

          switch (choice)
          {
              case 1:
                  ShowAvailableRooms();
                  break;
              case 2:
                  CheckIn();
                  break;
              case 3:
                  ShowReservedRooms();
                  break;
              case 4:
                  CheckOut();
                  break;
              case 5:
                  Console.WriteLine("Logging out...");
                  return false;
              default:
                  Console.WriteLine("Invalid choice.");
                  break;
          }

          return true;
      }
       
      static void ShowAvailableRooms() { 
      
        foreach (var room in room_list)
     
        
        {
            if (room.IsAvailable)
          {
            Console.WriteLine($"+ Room number: {room.Number}; Capacity: {room.Capacity}");
             
            }
        }
    }

    
      static void CheckIn()
      {
          Console.Write("--> Input number of people: ");
          int numPeople = Convert.ToInt32(Console.ReadLine());

          var availableRooms = room_list.FindAll(room => room.IsAvailable && room.Capacity >= numPeople);

          if (availableRooms.Count == 0)
          {
              Console.WriteLine("No suitable room at this time.");
              return;
          }

          Console.WriteLine("Available rooms:");
          foreach (var room in availableRooms)
          {
              Console.WriteLine($"Room number: {room.Number}, Capacity: {room.Capacity}");
          }

          Console.Write("Enter room number to check in: ");
          int roomNumber = Convert.ToInt32(Console.ReadLine());

          var roomToCheckIn = room_list.Find(room => room.Number == roomNumber && room.IsAvailable);

          if (roomToCheckIn == null)
          {
              Console.WriteLine("Invalid room number.");
              return;
          }

          Console.Write("Enter customer name: ");
          string customerName = Console.ReadLine();

          Console.Write("Enter customer email: ");
          string customerEmail = Console.ReadLine();

          roomToCheckIn.IsAvailable = false;
          roomToCheckIn.CustomerName = customerName;
          roomToCheckIn.CustomerEmail = customerEmail;

          Console.WriteLine($"Successfully checked in {customerName} to room {roomNumber}.");
      }

    

    static void ShowReservedRooms()
    {
        foreach (var room in room_list)
        {
            if (!room.IsAvailable)
            {
                Console.WriteLine($"Room number: {room.Number}, Customer name: {room.CustomerName}");
            }
        }
    }

    static void CheckOut()
  
       {
           Console.Write("--> Please input room number: ");
           int roomNumber = Convert.ToInt32(Console.ReadLine());

           var roomToCheckOut = room_list.Find(room => room.Number == roomNumber && !room.IsAvailable);

           if (roomToCheckOut == null)
           {
               Console.WriteLine("--> Could not find customer record of this room \n *******************");
               return;
           }

           Console.WriteLine($"Customer name: {roomToCheckOut.CustomerName}");
           Console.Write("Confirm check-out (y/n): ");
           string confirm = Console.ReadLine();

           if (confirm.ToLower() == "y")
           {
               roomToCheckOut.IsAvailable = true;
               roomToCheckOut.CustomerName = null;
               roomToCheckOut.CustomerEmail = null;

               Console.WriteLine($"Successfully checked out room {roomNumber}.");
           }
           else
           {
               Console.WriteLine("Check-out cancelled.");
           }
       }
    

    static void LogOut()
    {
        Console.WriteLine("Logging out...");
        Environment.Exit(0);
    } 
      }
  }
      
      

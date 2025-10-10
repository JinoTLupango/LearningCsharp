using System;
using System.Collections.Generic;

namespace UserInfoApp
{
    class Program
    {
        // A simple User class to store info
        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
        }

        static void Main(string[] args)
        {
            // A list to store users (temporary storage)
            List<User> users = new List<User>();
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== USER INFORMATION SYSTEM ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. View Users");
                Console.WriteLine("3. Exit");
                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(users);
                        break;
                    case "2":
                        ViewUsers(users);
                        break;
                    case "3":
                        running = false;
                        Console.WriteLine("Exiting program... Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        static void AddUser(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("=== ADD USER ===");

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.WriteLine("Enter your Address: ");
            string address = Console.ReadLine();

            users.Add(new User { Name = name, Age = age, Email = email, Address = address });

            Console.WriteLine("\n✅ User added successfully!");
        }

        static void ViewUsers(List<User> users)
        {
            Console.Clear();
            Console.WriteLine("=== USER LIST ===");

            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine("\n--------------------------");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Address: {user.Address}");
            }
        }
    }
}

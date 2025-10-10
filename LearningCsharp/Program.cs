using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace UpgradedCRUD
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }

    class Program
    {
        static List<User> users = new List<User>();
        static int nextId = 1;
        static string filePath = "users.json";

        static void Main(string[] args)
        {
            LoadData();

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== USER MANAGEMENT SYSTEM ===");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. View Users");
                Console.WriteLine("3. Update User");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("5. Search User");
                Console.WriteLine("6. Exit");
                Console.Write("\nChoose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddUser(); break;
                    case "2": ViewUsers(); break;
                    case "3": UpdateUser(); break;
                    case "4": DeleteUser(); break;
                    case "5": SearchUser(); break;
                    case "6":
                        running = false;
                        SaveData();
                        Console.WriteLine("\nExiting... Goodbye!");
                        break;
                    default:
                        ShowMessage("Invalid option, try again!", ConsoleColor.Red);
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        // ADD USER
        static void AddUser()
        {
            Console.Clear();
            Console.WriteLine("=== ADD USER ===");

            Console.Write("Enter name: ");
            string name = Console.ReadLine()?.Trim();

            Console.Write("Enter age: ");
            int age = int.TryParse(Console.ReadLine(), out int parsedAge) ? parsedAge : 0;

            Console.Write("Enter email: ");
            string email = Console.ReadLine()?.Trim();

            Console.Write("Enter address: ");
            string address = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email))
            {
                ShowMessage("Name and Email cannot be empty!", ConsoleColor.Red);
                return;
            }

            users.Add(new User
            {
                Id = nextId++,
                Name = name,
                Age = age,
                Email = email,
                Address = address
            });

            SaveData();
            ShowMessage("User added successfully!", ConsoleColor.Green);
        }

        // VIEW USERS
        static void ViewUsers()
        {
            Console.Clear();
            Console.WriteLine("=== USER LIST ===");

            if (users.Count == 0)
            {
                ShowMessage("No users found.", ConsoleColor.Yellow);
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"\nID: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"Age: {user.Age}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Address: {user.Address}");
                Console.WriteLine("----------------------------");
            }
        }

        // UPDATE USER
        static void UpdateUser()
        {
            Console.Clear();
            Console.WriteLine("=== UPDATE USER ===");

            Console.Write("Enter user ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var user = users.Find(u => u.Id == id);
                if (user != null)
                {
                    Console.Write($"Enter new name (current: {user.Name}): ");
                    string name = Console.ReadLine()?.Trim();

                    Console.Write($"Enter new age (current: {user.Age}): ");
                    string ageInput = Console.ReadLine();
                    if (int.TryParse(ageInput, out int newAge))
                        user.Age = newAge;

                    Console.Write($"Enter new email (current: {user.Email}): ");
                    string email = Console.ReadLine()?.Trim();

                    Console.Write($"Enter new address (current: {user.Address}): ");
                    string address = Console.ReadLine()?.Trim();

                    if (!string.IsNullOrWhiteSpace(name)) user.Name = name;
                    if (!string.IsNullOrWhiteSpace(email)) user.Email = email;
                    if (!string.IsNullOrWhiteSpace(address)) user.Address = address;

                    SaveData();
                    ShowMessage("User updated successfully!", ConsoleColor.Green);
                }
                else
                {
                    ShowMessage("User not found!", ConsoleColor.Red);
                }
            }
            else
            {
                ShowMessage("Invalid ID input!", ConsoleColor.Yellow);
            }
        }

        // DELETE USER
        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("=== DELETE USER ===");

            Console.Write("Enter user ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var user = users.Find(u => u.Id == id);
                if (user != null)
                {
                    users.Remove(user);
                    SaveData();
                    ShowMessage("User deleted successfully!", ConsoleColor.Green);
                }
                else
                {
                    ShowMessage("User not found!", ConsoleColor.Red);
                }
            }
            else
            {
                ShowMessage("Invalid ID!", ConsoleColor.Yellow);
            }
        }

        // SEARCH USER
        static void SearchUser()
        {
            Console.Clear();
            Console.WriteLine("=== SEARCH USER ===");

            Console.Write("Enter name or email: ");
            string keyword = Console.ReadLine()?.Trim().ToLower();

            var results = users.FindAll(u =>
                u.Name.ToLower().Contains(keyword) || u.Email.ToLower().Contains(keyword)
            );

            if (results.Count == 0)
            {
                ShowMessage("No matching users found.", ConsoleColor.Yellow);
                return;
            }

            Console.WriteLine("\nSearch Results:");
            foreach (var user in results)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Name: {user.Name}");
                Console.WriteLine($"AGE: {user.Age}");
                Console.WriteLine($"EMAIL: {user.Email}");
                Console.WriteLine($"ADDRESS: {user.Address}");



            }
        }

        // SAVE TO JSON FILE
        static void SaveData()
        {
            var json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        // LOAD JSON FILE
        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                users = JsonSerializer.Deserialize<List<User>>(json);
                nextId = users.Count > 0 ? users[^1].Id + 1 : 1;
            }
        }

        // COLOR MESSAGE DISPLAY
        static void ShowMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}

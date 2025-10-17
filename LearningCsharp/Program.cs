using System;

class Program
{
    public static void Main()
    {
        string answer;

        do
        {
            // nangayo og pangan
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            // nangayo og edad
            Console.Write("Enter your Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            // nangayo ug paborito programming language
            Console.Write("Enter your favorite programming language: ");
            string language = Console.ReadLine();

            // iya i display ang user info
            Console.WriteLine("\n--- User Information ---");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Favorite Language: " + language);

            // if else statement basi sa age
            if (age < 13)
            {
                Console.WriteLine("You're still young, " + name + "! Keep learning new things!");
            }
            else if (age >= 13 && age < 20)
            {
                Console.WriteLine("You're a teenager, " + name + "! Enjoy exploring coding!");
            }
            else if (age >= 20 && age < 50)
            {
                Console.WriteLine("You're an adult, " + name + "! Keep up the great work!");
            }
            else
            {
                Console.WriteLine("You're a senior, " + name + "! Your wisdom is inspiring!");
            }

            Console.WriteLine("\n --- Programing langauge Message ---");
            switch (language.ToLower())
            {
                case "C#":
                    Console.WriteLine("Nice! C# is a powerful for building desktop and web app!");
                    break;

                case "Java":
                    Console.WriteLine("Java is a great for enterpise system and android development!");
                    break;

                case "Python":
                    Console.WriteLine("Python is awesome for  AI and data science!");
                    break;

                case "PHP":
                    Console.WriteLine("PHP is used for web development!");
                    break;

                case "Javascript":
                    Console.WriteLine("Javascript is makes website!");
                    break;

                default:
                    Console.WriteLine("That is great langauge, " + name + "!keep coding!");
                    break;

            }
            Console.Write("\nDo you want to try again? (yes/no): ");
            answer = Console.ReadLine().ToLower();

        } while (answer == "yes");

        Console.WriteLine("Thank you for using the program! Goodbye!");
    }
}

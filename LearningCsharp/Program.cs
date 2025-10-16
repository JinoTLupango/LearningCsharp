using System;

class Program
{
    public static void Main() 
    {
        //nangayo og pangan
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        //nangayo og edad
        Console.Write("Enter your Age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        //nangayo ug paborito programming langauge
        Console.Write("Enter your favorite programming langauge: ");
        string langauge = Console.ReadLine();

        // iya i desplay ang user info
        Console.WriteLine("\n--- User Information ---");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Favorite Langauge: " + langauge);

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
            Console.WriteLine("You're Adult, " + name + "! Keep up the great Work!");
        }
        else
        {
            Console.WriteLine("You're senior! " + name + "! Your wisdom is inspiring!");
        }

        Console.WriteLine("\nPress any key to exit....");
        Console.ReadLine();
    
    }
}
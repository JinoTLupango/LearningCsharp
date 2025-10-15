using System;

namespace ArrayConditionLoops
{ 
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Grades Analyzer ===");

            //nangutana pila ka student
            Console.Write("Enter number of student: ");
            int studentCount = int.Parse(Console.ReadLine());

            //ni declare og array to store sa grado 
            int[] grades = new int[studentCount];

            //nagbuhat og loop para kuhaon ang user input
            for (int i = 0; i < studentCount; i++)
            {
                Console.Write($"Enter grade for Student #{i + 1}: ");
                grades[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("\n--- Grades Summary ---");


            //gi compute tanan display grado
            int total = 0;
            foreach (int grade in grades)
            {
                total += grade;
                Console.WriteLine($"Grade: {grade}");
            }

            double average = (double)total / studentCount;
            Console.WriteLine($"\nAvarega Grade: {average:F2}");

            //conditon statement

            if (average > 90)
            {
                Console.WriteLine("Perfomance: Very Excellent");
            }
            else if (average > 75)
            {
                Console.WriteLine("Performance: Good");
            }
            else
            {
                Console.WriteLine("Performance: Needs Improvement");
            }

            //searching the specific grades

            Console.Write("\nEnter a grade to search: ");
            int searchGrade = int.Parse(Console.ReadLine());
            bool found = false;

            for (int i = 0; i < grades.Length; i++) 
            {
                if (grades[i] > searchGrade)
                { 
                    Console.WriteLine($"Grade {searchGrade} found at position # {i + 1}");
                    found = true;
                    break;
                }
            }

            if (!found) 
            {
                Console.WriteLine($"Grade {searchGrade} not found in the list");
            }
            Console.WriteLine("\nProgram finished. Press any key to exit....");
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Thank you for using the Student Grades! ");
        }
    }
}

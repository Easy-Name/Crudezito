using System.Data.SqlClient;
using System;
using System.Data;
using Crudezito.Models;
using Crudezito.Repositories;

namespace Crudezito
{
    public static class Program
    {

        static void Main()
        {
            bool loop = true;

            while (loop)
            {
                int decision = menu();

                switch (decision)
                {
                    case 1:
                        inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL);
                        ExerciseRepository.Insert(EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL); 
                        //preciso pegar os valores na main (não no método Create)
                        break;
                    case 2:
                        CurrentEntries();
                        PrintLine();
                        ExerciseRepository.ListAll();
                        PrintLine();
                        break;
                    case 3:
                        PrintLine();
                        ExerciseRepository.ListByID(exerciseID());
                        PrintLine();
                        break;
                    case 4:
                        inputs(out EXERCISE_ID, out EXERCISE_NAME, out FOCUS_BODY_PART, out DIFFICULTY_LEVEL);
                        ExerciseRepository.Update(EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL);
                        break;
                    case 5:
                        ExerciseRepository.Delete(exerciseID());
                        break;
                    case 6:
                        loop = false;
                        ByeMessage();
                        break;
                }
            }
                
            Console.ReadLine();
        }

        static int menu()
        {

            List<int> menuOptions = new List<int>() {1,2,3,4,5,6};
            int decision = default;

            do
            {

                Console.WriteLine($"What would you like to do?:");
                Console.WriteLine($"1 - CREATE entry");
                Console.WriteLine($"2 - List All");
                Console.WriteLine($"3 - List entry by ID");
                Console.WriteLine($"4 - UPDATE entry");
                Console.WriteLine($"5 - DELETE entry");
                Console.WriteLine($"6 - Exit Program");

                decision = Convert.ToInt32(Console.ReadLine());
                if (!menuOptions.Contains(decision))
                {
                    Console.WriteLine($"Enter a valid option, {decision} is invalid!");
                }
            } while (!menuOptions.Contains(decision));
            
            return decision;
        }



        public static void inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL)
        {
            PrintLine();
            Console.Write($"EXERCISE_ID (int, ex: 100, 185, 399) = ");
            EXERCISE_ID = Convert.ToInt32(Console.ReadLine());
            Console.Write($"EXERCISE_NAME (string, ex: 'Stiff', 'RDL', 'Rows') = ");
            EXERCISE_NAME = Console.ReadLine();
            Console.Write($"FOCUS_BODY_PART (string, ex: 'Chest', 'Back', 'Leg') = ");
            FOCUS_BODY_PART = Console.ReadLine();
            Console.Write($"DIFFICULTY_LEVEL (string, ex: 'Low', 'Medium', 'High') = ");
            DIFFICULTY_LEVEL = Console.ReadLine();
            PrintLine();
        }

        public static int exerciseID()
        {
            Console.Write($"EXERCISE_ID = ");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void PrintLine ()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        static void ByeMessage()
        {
            Console.WriteLine($"Bye!");
        }

        static void CurrentEntries()
        {
            Console.WriteLine($"Current database entries:");
        }


















    }
}

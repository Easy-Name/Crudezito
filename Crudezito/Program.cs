using System.Data.SqlClient;
using System;
using System.Data;
using Crudezito.Models;
using Crudezito.Repositories;

namespace Crudezito
{
    public class Program
    {
        void main()
        {
            CRUD();
            Console.ReadLine();
        }


        public void CRUD()
        {
            //Responsible for interacting with the user (collecting and displaying information and messages)

            bool loop = true;
            var exerciseRepository = new ExerciseRepository();

            while (loop)
            {
                int decision = Menu();

                switch (decision)
                {
                    case 1:
                        Inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL);
                        var result = exerciseRepository.Insert(EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL);

                        break;
                    case 2:
                        CurrentEntries();
                        PrintLine();
                        var getAll = exerciseRepository.GetAll(); //TODO----------------------------------
                        PrintLine();
                        break;
                    case 3:
                        PrintLine();
                        var getById = exerciseRepository.GetByID(ExerciseID()); //TODO--------------------------
                        Console.WriteLine(getById.ExerciseId);
                        Console.WriteLine(getById.ExerciseName);
                        Console.WriteLine(getById.FocusBodyPart);
                        Console.WriteLine(getById.DifficultyLevel);


                        PrintLine();
                        break;
                    case 4:
                        Inputs(out EXERCISE_ID, out EXERCISE_NAME, out FOCUS_BODY_PART, out DIFFICULTY_LEVEL);
                        result = exerciseRepository.Update(EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL);
                        break;
                    case 5:
                        result = exerciseRepository.Delete(ExerciseID());
                        PrintLine();
                        break;
                    case 6:
                        loop = false;
                        PrintLine();
                        ByeMessage();
                        break;
                }
            }
        }

        public int Menu()
        {

            List<int> menuOptions = new List<int>() { 1, 2, 3, 4, 5, 6 };
            int decision = default;

            do
            {
                Console.WriteLine($"What would you like to do?:");
                Console.WriteLine($"1 - Insert entry");
                Console.WriteLine($"2 - List All");
                Console.WriteLine($"3 - List entry by ID");
                Console.WriteLine($"4 - Update entry");
                Console.WriteLine($"5 - Delete entry");
                Console.WriteLine($"6 - Exit Program");

                decision = Convert.ToInt32(Console.ReadLine());
                if (!menuOptions.Contains(decision))
                {
                    Console.WriteLine($"Enter a valid option, {decision} is invalid!");
                }
            } while (!menuOptions.Contains(decision));

            return decision;
        }



        public void Inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL)
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

        public int ExerciseID()
        {
            Console.Write($"EXERCISE_ID = ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public void PrintLine()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
        }

        public void ByeMessage()
        {
            Console.WriteLine($"Bye!");
        }

        public void CurrentEntries()
        {
            Console.WriteLine($"Current database entries:");
        }

    }
}


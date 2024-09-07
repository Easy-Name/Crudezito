using System.Data.SqlClient;
using System;
using System.Data;
using Crudezito.Models;
using Crudezito.Repositories;

namespace Crudezito
{
    public class Program
    {
        static void Main()
        {
            var program = new Program();
            program.CRUD();
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
                        InputsCreate(out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL);
                        Exercises Item = new Exercises(EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL);

                        //parametro das funções serem uma classe exercise

                        var result = exerciseRepository.Insert(Item);

                        break;
                    case 2:
                        CurrentEntries();
                        PrintLine();
                        var getAll = exerciseRepository.GetAll(); 

                        for (int i = 0; i < getAll.Count(); i++)
                        {
                            Console.WriteLine($"Exercise ID: {getAll[i].ExerciseId}");
                            Console.WriteLine($"Exercise Name: {getAll[i].ExerciseName}");
                            Console.WriteLine($"Target Body Part: {getAll[i].FocusBodyPart}");
                            Console.WriteLine($"Difficulty Level: {getAll[i].DifficultyLevel}");
                            Console.WriteLine();
                        }

                        PrintLine();
                        break;
                    case 3:
                        PrintLine();
                        var getById = exerciseRepository.GetByID(ExerciseID()); 
                        Console.WriteLine($"Exercise ID: {getById.ExerciseId}");
                        Console.WriteLine($"Exercise Name: {getById.ExerciseName}");
                        Console.WriteLine($"Target Body Part: {getById.FocusBodyPart}");
                        Console.WriteLine($"Difficulty Level: {getById.DifficultyLevel}");
                        PrintLine();
                        break;
                    case 4:
                        InputsUpdate(out int EXERCISE_ID, out EXERCISE_NAME, out FOCUS_BODY_PART, out DIFFICULTY_LEVEL);

                        Exercises ItemUpdate = new Exercises(EXERCISE_ID, EXERCISE_NAME , FOCUS_BODY_PART , DIFFICULTY_LEVEL);
                        result = exerciseRepository.Update(ItemUpdate);
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
                Console.WriteLine($"2 - Get All");
                Console.WriteLine($"3 - Get entry by ID");
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
        public void InputsUpdate(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL)
        {
            PrintLine();
            Console.Write($"EXERCISE_ID (int, ex: 100, 185, 399) = ");
            EXERCISE_ID = Convert.ToInt32(Console.ReadLine());
            Console.Write($"EXERCISE_NAME (string, ex: 'Stiff', 'RDL', 'Rows') = ");
            EXERCISE_NAME = TreatString(Console.ReadLine());
            Console.Write($"FOCUS_BODY_PART (string, ex: 'Chest', 'Back', 'Leg') = ");
            FOCUS_BODY_PART = TreatString(Console.ReadLine());
            Console.Write($"DIFFICULTY_LEVEL (string, ex: 'Low', 'Medium', 'High') = ");
            DIFFICULTY_LEVEL = TreatString(Console.ReadLine());
            PrintLine();
        }
        public void InputsCreate(out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL)
        {
            PrintLine();
            Console.Write($"EXERCISE_NAME (string, ex: 'Stiff', 'RDL', 'Rows') = ");
            EXERCISE_NAME = TreatString(Console.ReadLine());
            Console.Write($"FOCUS_BODY_PART (string, ex: 'Chest', 'Back', 'Leg') = ");
            FOCUS_BODY_PART = TreatString(Console.ReadLine());
            Console.Write($"DIFFICULTY_LEVEL (string, ex: 'Low', 'Medium', 'High') = ");
            DIFFICULTY_LEVEL = TreatString(Console.ReadLine());
            PrintLine();
        }

        string TreatString(string @string)
        {
            char v = '\'';
            if (@string[0] == v && @string[@string.Length-1] == v)
            {
                return @string;
            }
            else 
            {
                return "'"+@string+"'";
            }
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


using System.Data.SqlClient;
using System;
using System.Data;

namespace Crudezito
{
    public static class Program
    {

        public const string connectionString = @"Data Source =DESKTOP-S72P1K4\SQLEXPRESS; Initial " +
            @"Catalog = MyDb; Integrated Security = true";



        static void Main()
        {

            
            bool loop = true;


            while (loop)
            {
                int decision = menu();

                switch (decision)
                {
                    case 1:
                        CRUDCreate();
                        break;
                    case 2:
                        CRUDRead(false);
                        break;
                    case 3:
                        CRUDUpdate();
                        break;
                    case 4:
                        CRUDDelete();
                        break;
                    case 5:
                        loop = false;
                        Console.WriteLine("Bye!");
                        break;
                }
            }
                
            Console.ReadLine();

        }

        static int menu()
        {

            List<int> menuOptions = new List<int>() {1,2,3,4,5};
            int decision = default;

            do
            {
                Console.WriteLine($"Current database entries:");
                PrintLine();
                CRUDRead(true);
                PrintLine();
                Console.WriteLine($"What would you like to do?:");
                Console.WriteLine($"1 - CREATE entry");
                Console.WriteLine($"2 - READ entry");
                Console.WriteLine($"3 - UPDATE entry");
                Console.WriteLine($"4 - DELETE entry");
                Console.WriteLine($"5 - Exit Program");

                decision = Convert.ToInt32(Console.ReadLine());
                if (!menuOptions.Contains(decision))
                {
                    Console.WriteLine($"Enter a valid option, {decision} is invalid!");
                }
            } while (!menuOptions.Contains(decision));
            
            return decision;
        }

        static void CRUDCreate()
        {
            inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL);

            //create command that I want to query (insert into DB)
            string queryStringC = "insert into EXERCISE (EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL) " +
                                  $"values ({EXERCISE_ID}, {EXERCISE_NAME}, {FOCUS_BODY_PART}, {DIFFICULTY_LEVEL});";

            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(Program.connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand CreateCommand = new(queryStringC, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    CreateCommand.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void CRUDRead(bool ListAll)
        {

            string queryStringR = $"select * from dbo.EXERCISE";

            if (!ListAll)
            {
                Console.Write($"EXERCISE_ID = ");
                int EXERCISE_ID = Convert.ToInt32(Console.ReadLine());
                queryStringR = $"select * from dbo.EXERCISE where EXERCISE_ID = {EXERCISE_ID}";
            }

            //create command that I want to query (insert into DB)
            
            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(Program.connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand ReadCommand = new(queryStringR, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    //SqlDataReader reader = ReadCommand.ExecuteReader();

                    PrintLine();
                    SqlDataReader reader = ReadCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",
                            reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                    PrintLine();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        static void CRUDUpdate()
        {

            inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL);


            //create command that I want to query (insert into DB)
            string queryStringU = $"update dbo.EXERCISE SET EXERCISE_NAME = {EXERCISE_NAME}, FOCUS_BODY_PART = {FOCUS_BODY_PART}, DIFFICULTY_LEVEL = {DIFFICULTY_LEVEL}  WHERE EXERCISE_ID = {EXERCISE_ID}";
            

            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(Program.connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand UpdateCommand = new(queryStringU, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    UpdateCommand.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        static void CRUDDelete()
        {

            Console.Write($"EXERCISE_ID = ");
            int EXERCISE_ID = Convert.ToInt32(Console.ReadLine());

            //create command that I want to query (insert into DB)
            string queryStringD = $"DELETE FROM dbo.EXERCISE WHERE EXERCISE_ID = {EXERCISE_ID};";


            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(Program.connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand DeleteCommand = new(queryStringD, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    DeleteCommand.ExecuteNonQuery();

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        static void inputs(out int EXERCISE_ID, out string EXERCISE_NAME, out string FOCUS_BODY_PART, out string DIFFICULTY_LEVEL)
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



        static void PrintLine ()
        {
            Console.WriteLine("---------------------------------------------------------------------------------");
        }




















    }
}

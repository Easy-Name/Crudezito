using System.Data.SqlClient;
using System;

namespace Crudezito
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source =DESKTOP-S72P1K4\SQLEXPRESS; Initial " +
                @"Catalog = MyDb; Integrated Security = true";

            string queryString = @"select * from dbo.EXERCISE";
            //string queryStringC = @"insert into EXERCISE (EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL) " +
            //@"values (8, 'Shoulder Press', 'Shoulder', 'Low');";

            using (SqlConnection connection = new(connectionString)) 
            {
                SqlCommand command = new(queryString, connection);
                //SqlCommand InsertCommand = new(queryStringC, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",
                            reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }



                Console.ReadLine();

            }
        }
    }
}

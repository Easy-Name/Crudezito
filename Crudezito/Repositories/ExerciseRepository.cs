using Crudezito.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudezito.Repositories
{
    public class ExerciseRepository
    {
        //Classe que faz acesso a dados

        public static string connectionString = @"Data Source =DESKTOP-S72P1K4\SQLEXPRESS; Initial " +
        @"Catalog = MyDb; Integrated Security = true";

        public static void Insert(int EXERCISE_ID, string EXERCISE_NAME, string FOCUS_BODY_PART, string DIFFICULTY_LEVEL)
        {

            //create command that I want to query (insert into DB)
            string queryStringC = "insert into EXERCISE (EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL) " +
                                  $"values ({EXERCISE_ID}, {EXERCISE_NAME}, {FOCUS_BODY_PART}, {DIFFICULTY_LEVEL});";

            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(connectionString))
            using (SqlCommand CreateCommand = new(queryStringC, connection))
            {
                //Creating the command object that the query is going to execute, giving the connection object 

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
                finally
                {
                    //TODO: if (connection. null) { VERIFICAR SE A CONEXÃO ESTÁ ABERTA, CASO ESTEJA ABERTA EU FECHO ELA, CASO NÃO ESTEJA ABERTA, NÃO FAÇO NADA, VERIFICAR SE O USING TAMBÉM MATA A CONEXÃO
                    connection.Close();
                }
            }
        }

        public static void ListAll() //TODO PRECISO RETORNAR UMA CLASSE COM OS CAMPOS PREENCHIDOS
        {

            string queryStringR = $"select * from dbo.EXERCISE";

            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand ReadCommand = new(queryStringR, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    SqlDataReader reader = ReadCommand.ExecuteReader();
                    var exercises = new List<Exercises>();

                    while (reader.Read())
                    {

                        var exercise = new Exercises();
                        exercise.Id = Convert.ToInt32(reader[0]);
                        //exercise.name = Convert.ToInt32(reader[1]);
                        //exercise.Id = Convert.ToInt32(reader[2]);
                        //exercise.Id = Convert.ToInt32(reader[3]);

                        exercises.Add(exercise);


                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",
                            reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static void ListByID(int EXERCISE_ID) //TODO PRECISO RETORNAR UMA CLASSE COM OS CAMPOS PREENCHIDOS
        {


            string queryStringR = $"select * from dbo.EXERCISE where EXERCISE_ID = {EXERCISE_ID}";

            //TODO separar o list all do list por ID
            using (SqlConnection connection = new(connectionString))
            {
                SqlCommand ReadCommand = new(queryStringR, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    SqlDataReader reader = ReadCommand.ExecuteReader();
                    var exercises = new List<Exercises>();

                    while (reader.Read())
                    {

                        var exercise = new Exercises();
                        exercise.Id = Convert.ToInt32(reader[0]);
                        //exercise.name = Convert.ToInt32(reader[1]);
                        //exercise.Id = Convert.ToInt32(reader[2]);
                        //exercise.Id = Convert.ToInt32(reader[3]);

                        exercises.Add(exercise);


                        Console.WriteLine("\t{0}\t{1}\t{2}\t{3}",
                            reader[0], reader[1], reader[2], reader[3]);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public static void Update(int EXERCISE_ID, string EXERCISE_NAME, string FOCUS_BODY_PART, string DIFFICULTY_LEVEL)
        {
            //create command that I want to query (update entry of DB)
            string queryStringU = $"update dbo.EXERCISE SET EXERCISE_NAME = {EXERCISE_NAME}, FOCUS_BODY_PART = {FOCUS_BODY_PART}, DIFFICULTY_LEVEL = {DIFFICULTY_LEVEL}  WHERE EXERCISE_ID = {EXERCISE_ID}";

            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand UpdateCommand = new(queryStringU, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    var result = UpdateCommand.ExecuteNonQuery();
                    //return result > 0

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }


        public static void Delete(int EXERCISE_ID)
        {

            

            //create command that I want to query (delete entry of DB)
            string queryStringD = $"DELETE FROM dbo.EXERCISE WHERE EXERCISE_ID = {EXERCISE_ID};";


            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new(connectionString))
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




















    }
}

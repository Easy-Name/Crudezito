using Crudezito.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Crudezito.Repositories
{
    public class ExerciseRepository
    {
        //this class controls all access to database
        //this class is my backend


        private readonly string _connectionString = @"Data Source =DESKTOP-S72P1K4\SQLEXPRESS; Initial " +
        @"Catalog = MyDb; Integrated Security = true";
        //readonly is like const, but you can alter it in the class constructor, const cant be altered in the class constructor

        public bool Insert(int EXERCISE_ID, string EXERCISE_NAME, string FOCUS_BODY_PART, string DIFFICULTY_LEVEL)
        {

            //create command that I want to query (insert into DB)
            string queryStringC = "insert into EXERCISE (EXERCISE_ID, EXERCISE_NAME, FOCUS_BODY_PART, DIFFICULTY_LEVEL) " +
                                  $"values ({EXERCISE_ID}, {EXERCISE_NAME}, {FOCUS_BODY_PART}, {DIFFICULTY_LEVEL});";

            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (SqlConnection connection = new (_connectionString))
            using (SqlCommand CreateCommand = new(queryStringC, connection))
            {
                //Creating the command object that the query is going to execute, giving the connection object 

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    var result = CreateCommand.ExecuteNonQuery();

                    return result > 0;

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    //TODO: if (connection. null) { VERIFICAR SE A CONEXÃO ESTÁ ABERTA, CASO ESTEJA ABERTA EU FECHO ELA, CASO NÃO ESTEJA ABERTA, NÃO FAÇO NADA, VERIFICAR SE O USING TAMBÉM MATA A CONEXÃO
                    connection.Close();
                }
            }
        }

        public List<Exercises> GetAll() 
        {

            string queryStringR = $"select * from dbo.EXERCISE";

            using (SqlConnection connection = new(_connectionString))
            {
                SqlCommand ReadCommand = new(queryStringR, connection);
                //SqlDataReader reader = ReadCommand.ExecuteReader();

                try
                {
                    //establish connection
                    connection.Open();
                    SqlDataReader reader = ReadCommand.ExecuteReader();

                    //execute command
                    //SqlDataReader reader = ReadCommand.ExecuteReader();
                    var exercises = new List<Exercises>();

                    while (reader.Read())
                    {
                        var exercise = new Exercises();
                        exercise.ExerciseId = Convert.ToInt32(reader[0]);
                        exercise.ExerciseName = reader[1].ToString();
                        exercise.FocusBodyPart = reader[2].ToString();
                        exercise.DifficultyLevel = reader[3].ToString();

                        exercises.Add(exercise);

                    }
                    //reader.Close();
                    return exercises;
                }

                catch (Exception)
                {
                    //Console.WriteLine(ex.Message);
                    // return empty object
                    //return null
                    //return exception throw new exception
                    //throw new Exception("deu erro ao consultar item do banco"); (tratamento de exception)
                    //throw ex;
                    //adicionar log
                    //exception is different from Exception
                    throw; //vai retornar a string que está no ex

                }
                finally //used to execute what i want to guarantee that will be executed
                {
                    //reader.Close();
                    ReadCommand.Dispose(); //using dispose i will have to create a new object if i want to use it again
                }
            }
        }

        public Exercises GetByID(int exerciseId) //TODO PRECISO RETORNAR UMA CLASSE COM OS CAMPOS PREENCHIDOS
        {
            string queryStringR = $"select * from dbo.EXERCISE where EXERCISE_ID = {exerciseId}";

            //TODO separar o list all do list por ID
            using (SqlConnection connection = new(_connectionString))
            {
                SqlCommand ReadCommand = new(queryStringR, connection);
                

                try
                {
                   //establish connection
                   connection.Open();
                   SqlDataReader reader = ReadCommand.ExecuteReader();

                    //execute command
                    reader.Read();
                    
                   var exercise = new Exercises();
                   exercise.ExerciseId = Convert.ToInt32(reader[0]);
                   exercise.ExerciseName = reader[1].ToString();
                   exercise.FocusBodyPart = reader[2].ToString();
                   exercise.DifficultyLevel = reader[3].ToString();

                    return exercise;
                }

                catch (Exception)
                {
                    //Console.WriteLine(ex.Message);
                    throw;
                }
                finally //used to execute what i want to guarantee that will be executed
                {
                    //reader.Close();
                    ReadCommand.Dispose(); //using dispose i will have to create a new object if i want to use it again
                }
            }
        }

        public bool Update(int exerciseId, string exerciseName, string focusBodyPart, string difficultyLevel)
        {
            //create command that I want to query (update entry of DB)
            string queryStringU = $"update dbo.EXERCISE SET EXERCISE_NAME = {exerciseName}, FOCUS_BODY_PART = {focusBodyPart}, DIFFICULTY_LEVEL = {difficultyLevel}  WHERE EXERCISE_ID = {exerciseId}";

            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (var connection = new SqlConnection(_connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand UpdateCommand = new(queryStringU, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    var result = UpdateCommand.ExecuteNonQuery();
                    return result > 0;

                }

                catch (Exception)
                {
                    //Console.WriteLine(ex.Message);
                    throw;
                    //return false;
                }
                finally //used to execute what i want to guarantee that will be executed
                {
                    UpdateCommand.Dispose(); //using dispose i will have to create a new object if i want to use it again
                }

            }
        }

        public bool Delete(int EXERCISE_ID) 
        {
            
            //create command that I want to query (delete entry of DB)
            string queryStringD = $"DELETE FROM dbo.EXERCISE WHERE EXERCISE_ID = {EXERCISE_ID};";


            //First create connection object
            //using "using" you guarantee that the connection is closed after code block execution

            using (var connection = new SqlConnection(_connectionString))
            {
                //Creating the command object that the query is going to execute, giving the connection object 
                SqlCommand DeleteCommand = new(queryStringD, connection);

                try
                {
                    //establish connection
                    connection.Open();

                    //execute command
                    var result = DeleteCommand.ExecuteNonQuery();
                    return result > 0;

                }

                catch (Exception)
                {
                    throw;
                }
                finally //used to execute what i want to guarantee that will be executed
                {
                    DeleteCommand.Dispose(); //using dispose i will have to create a new object if i want to use it again
                }

            }
        }

    }
}

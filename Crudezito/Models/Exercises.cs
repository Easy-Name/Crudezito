using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudezito.Models
{
    public class Exercises
    {
        public Exercises(string exerciseName, string focusBodyPart, string difficultyLevel)
        {
            //ExerciseId = exerciseId; -> I don't need exercise ID for create, because the database column ID is configureed as identity, so it creates the ID on it's own for the create method
            //ExerciseId = Guid.NewGuid();
            ExerciseName = exerciseName;
            FocusBodyPart = focusBodyPart;
            DifficultyLevel = difficultyLevel;
        }


        public Exercises(int exerciseId, string exerciseName, string focusBodyPart, string difficultyLevel)
        {
            ExerciseId = exerciseId;         
            ExerciseName = exerciseName;
            FocusBodyPart = focusBodyPart;
            DifficultyLevel = difficultyLevel;
        }

        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string FocusBodyPart { get; set; }
        public string DifficultyLevel { get; set; }
    }
}

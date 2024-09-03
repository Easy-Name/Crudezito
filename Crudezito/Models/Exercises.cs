using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crudezito.Models
{
    public class Exercises
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public string FocusBodyPart { get; set; }
        public string DifficultyLevel { get; set; }
    }
}

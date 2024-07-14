using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Esta entidad representa ejercicios que 
    ///  se van a realizar en una sesion.
    /// Tengo 1 o varios Items por sesion.
    /// Tengo 0 o 1 sesion por set
    ///  Si es 0, es configuracion
    /// </summary>
    public class Item
    {
        public int ID { get; set; }

        public int Series { get; set; }
        public int Repetitions { get; set; }
        public float? Weight { get; set; }
        public int? WeightStacks { get; set; } // cantidad de bloques de peso


        [ForeignKey("Session")]
        public int? SessionID { get; set; }
        [JsonIgnore]
        public virtual Session? Session { get; set; }



        public int ExerciseId { get; set; }
        public string? ExerciseName { get; set; }
        public string? ExerciseType { get; set; }

    }
}

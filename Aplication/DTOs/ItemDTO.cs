namespace Application.DTOs
{
    public class ItemDTO
    {
        public int ID { get; set; }

        public int Series { get; set; }
        public int Repetitions { get; set; }
        public float? Weight { get; set; }
        public int? WeightStacks { get; set; } // cantidad de bloques de peso

        public int ExerciseId { get; set; }
        public string? ExerciseName { get; set; }
        public string? ExerciseType { get; set; }

        public int? SessionID { get; set; }
    }
}

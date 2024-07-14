using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public static class ItemsMapper
    {
        public static ItemDTO ItemToDTO(Item item)
        {
            return new ItemDTO
            {
                ID = item.ID,
                Series = item.Series,
                Repetitions = item.Repetitions,
                Weight = item.Weight,
                WeightStacks = item.WeightStacks,
                ExerciseId = item.ExerciseId,
                ExerciseName = item.ExerciseName,
                ExerciseType = item.ExerciseType,
                SessionID = item.SessionID,
            };
        }

        public static Item DTOToItem(ItemDTO itemDTO)
        {
            return new Item
            {
                ID = itemDTO.ID,
                Series = itemDTO.Series,
                Repetitions = itemDTO.Repetitions,
                Weight = itemDTO.Weight,
                WeightStacks = itemDTO.WeightStacks,
                ExerciseId = itemDTO.ExerciseId,
                ExerciseName = itemDTO.ExerciseName,
                ExerciseType = itemDTO.ExerciseType,
                SessionID = itemDTO.SessionID,
            };
        }
    }
}

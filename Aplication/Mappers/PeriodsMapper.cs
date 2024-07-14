using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public static class PeriodsMapper
    {
        public static PeriodDTO PeriodToDTO(Period period)
        {
            return new PeriodDTO
            {
                ID = period.ID,
                UserID = period.UserID,
                StartDate = period.StartDate ?? null,
                EndDate = period.EndDate ?? null,
                TotalDaysActivesOnAPeriod = period.TotalDaysActivesOnAPeriod,
                Status = period.Status,
                Sessions = period.Sessions,
            };
        }

        public static Period DTOToPeriod(PeriodDTO periodDTO)
        {
            return new Period
            {
                ID = periodDTO.ID,
                UserID = periodDTO.UserID,
                StartDate = periodDTO.StartDate ?? null,
                EndDate = periodDTO.EndDate ?? null,
                TotalDaysActivesOnAPeriod = periodDTO.TotalDaysActivesOnAPeriod,
                Status = periodDTO.Status,
                Sessions = periodDTO.Sessions,
            };

        }
    }
}

using Application.DTOs;
using Domain.Entities;

namespace Application.Mappers
{
    public static class SessionsMapper
    {
        public static SessionDTO SessionToDTO(Session session)
        {
            return new SessionDTO
            {
                ID = session.ID,
                UserID = session.UserID,
                CreationDate = session.CreationDate ?? null,
                DayOfThePeriod = session.DayOfThePeriod,
                PeriodID = session.PeriodID ?? null,
                Items = session.Items,
            };
        }

        public static Session DTOToSession(SessionDTO sessionDTO)
        {
            return new Session
            {
                ID = sessionDTO.ID,
                UserID = sessionDTO.UserID,
                CreationDate = sessionDTO.CreationDate ?? null,
                DayOfThePeriod = sessionDTO.DayOfThePeriod,
                PeriodID = sessionDTO.PeriodID ?? null,
                Items = sessionDTO.Items,
            };

        }
    }
}

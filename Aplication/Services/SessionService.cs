using Application.DTOs;
using Application.Interfaces;
using Application.Mappers;

namespace Application.Services
{
    public class SessionService(IUnitOfWork unitOfWork) : ISessionService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<List<SessionDTO>?> GetAllSessionsAsync()
        {
            var sessions = await _unitOfWork.Sessions.GetAllAsync();

            List<SessionDTO> sessionDTO = [];

            if (sessions == null)
            {
                return null;
            }

            if (sessions != null)
            {
                foreach (var session in sessions)
                {
                    if (session != null)
                    {
                        var toDTO = SessionsMapper.SessionToDTO(session);
                        sessionDTO.Add(toDTO);
                    }
                }
            }

            return [.. sessionDTO];

        }

        public async Task<SessionDTO?> GetSessionByIdAsync(int id)
        {
            var session = await _unitOfWork.Sessions.GetSessionByIdWithItemsAsync(id);
            if (session is null)
            {
                return null;
            }

            var sessionDTO = SessionsMapper.SessionToDTO(session);

            return sessionDTO;
        }

        public async Task<Exception?> SetSessionAsync(SessionDTO sessionDTO)
        {
            try
            {
                var session = SessionsMapper.DTOToSession(sessionDTO);
                session.CreationDate = DateOnly.FromDateTime(DateTime.Now);
                await _unitOfWork.Sessions.AddAsync(session);
                await _unitOfWork.CompleteAsync();
                return null;

            }
            catch (Exception mje)
            {

                return new Exception($"Session don't be save because: {mje.Message}");
            }

        }
    }
}

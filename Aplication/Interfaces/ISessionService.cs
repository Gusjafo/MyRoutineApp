using Application.DTOs;

namespace Application.Interfaces
{
    public interface ISessionService
    {
        Task<List<SessionDTO>?> GetAllSessionsAsync();
        Task<SessionDTO?> GetSessionByIdAsync(int id);
        Task<Exception?> SetSessionAsync(SessionDTO sessionDTO);

    }
}

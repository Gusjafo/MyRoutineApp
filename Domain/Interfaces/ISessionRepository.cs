using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISessionRepository : IRepository<Session>
    {
        Task<Session?> GetSessionByIdWithItemsAsync(int id);        
    }
}

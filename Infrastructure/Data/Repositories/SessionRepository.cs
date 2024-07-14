
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class SessionRepository(RutinaContext context) : Repository<Session>(context), ISessionRepository
    {
        public async Task<Session?> GetSessionByIdWithItemsAsync(int id)
        {
            return await context.Sessions.AsNoTracking()
                                         .SingleOrDefaultAsync(i => i.ID == id);
        }
    }
}

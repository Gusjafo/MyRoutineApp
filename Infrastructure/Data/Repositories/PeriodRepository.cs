using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Enums;

namespace Infrastructure.Data.Repositories
{
    public class PeriodRepository(RutinaContext context) : Repository<Period>(context), IPeriodRepository
    {
        public async Task<Period?> GetPeriodWithSeassonByIdAsync(int Id)
        {
            return await context.Periods.Include(s => s.Sessions)
                                        .AsNoTracking()
                                        .SingleOrDefaultAsync(s => s.ID == Id);
        }

        public async Task<int?> FindActiveAsync(string userId)
        {
            var response = await context.Periods.Where(u => u.UserID == userId).Where(p => p.Status == Status.IsActive).SingleOrDefaultAsync();

            if (response == null)
            {
                return null;
            }

            return response.ID;
        }
    }
}
